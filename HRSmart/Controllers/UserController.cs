using HRSmart.Domain.Entities;
using HRSmart.Service.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace HRSmart.Controllers
{
    public class UserController : Controller
    {

        IServiceUser serviceuser = new ServiceUser();
        IServiceUserBuisness serviceuserbuisness = new ServiceUserBuisness();
        IServiceUserSkill serviceuserskill = new ServiceUserSkill();
        IServiceCertificat servicecertificat = new ServiceCertificat();
        // GET: User
        public ActionResult Index()
        {
            List<user> users = serviceuser.GetMany().ToList();

            foreach (var u in users)
            {
                Console.WriteLine(u.firstName);
                bool verif = false;
                foreach (var ub in serviceuserbuisness.findByuser(u.id))
                {
                    Console.WriteLine(ub.user_id);
                    if (ub.role == "HR")
                    {
                        u.role = "Chief Human Ressource";
                        verif = true;
                        break;

                    }
                    if (ub.role == "RM")
                    {
                        u.role = "Recruiter Manager";
                        verif = true;
                        break;
                    }
                    if (ub.role == "EMP")
                    {
                        u.role = "Employee";
                        verif = true;
                        break;
                    }

                }
                if (verif == false)
                {
                    u.role = "Non Employed";
                }

            }

            ViewBag.users = users;
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.user = serviceuser.GetById(id);
            return View();
        }

        // GET: User/Statistics
        public ActionResult Statistics()
        {
            ViewBag.userEmployed = serviceuser.getNumberOfEmployedUsers();
            ViewBag.employeecount = serviceuser.GetMany().ToList().Count;
            ViewBag.skillsuser = serviceuser.getAverageNumberOfSkillsUser();
            ViewBag.numberuserMonth = serviceuser.getUserPerMonth();
            return View();
        }

        public ActionResult Ban(int id)
        {
            user user = serviceuser.GetById(id);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("HRSmartTwin@gmail.com","HRSmart Support");
            mail.To.Add(new MailAddress(user.login));
                mail.Body = "Dear " + user.firstName + " " + user.lastName + ", Your account on HRSmart has been disabled due to your actions on our platform lately. This Ban might be permanant.";
            SmtpClient SMTPServer = new SmtpClient("smtp.live.com",587);


            SMTPServer.Credentials = new System.Net.NetworkCredential("HRSmart@outlook.fr", "Beyrem2016");
            SMTPServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SMTPServer.EnableSsl = true;
            try
            {
                SMTPServer.Send(mail);
            }
            catch(Exception e)
            {

            }

            if (user.active)
            {
                user.active = false;
            }
            else
            {
                user.active = true;
            }
            serviceuser.Update(user);
            serviceuser.commit();
            return RedirectToAction("Index", "User");
        }



    }
}
