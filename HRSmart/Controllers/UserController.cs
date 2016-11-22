using HRSmart.Domain.Entities;
using HRSmart.Models;
using HRSmart.Service.Business;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
        IServiceBusiness servicebuisness = new ServiceBusiness();
        // GET: User
        public ActionResult Index()
        {
            ApplicationUser user =
                System.Web.HttpContext.Current.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>()
                    .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            if (user.Roles.ElementAt(0).RoleId == "1")
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
            else
            {
                return RedirectToAction("IndexHR");
            }
        }



        // GET: User/Details/
        public ActionResult Details(int id)
        {
            ViewBag.user = serviceuser.GetById(id);
            return View();
        }

        // GET: User/Statistics
        public ActionResult Statistics()
        {
            ApplicationUser user =
                   System.Web.HttpContext.Current.GetOwinContext()
                       .GetUserManager<ApplicationUserManager>()
                       .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            if (user.Roles.ElementAt(0).RoleId == "1")
            {
                ViewBag.userEmployed = serviceuser.getNumberOfEmployedUsers();
            ViewBag.employeecount = serviceuser.GetMany().ToList().Count;
            ViewBag.skillsuser = serviceuser.getAverageNumberOfSkillsUser();
            ViewBag.numberuserMonth = serviceuser.getUserPerMonth();
            ViewBag.numberHR = serviceuser.getNumberofHR();
            return View();
            }
            else
            {
                return RedirectToAction("StatisticHR");
            }
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



        public ActionResult NBan(int id)
        {
            user user = serviceuser.GetById(id);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("HRSmartTwin@gmail.com", "HRSmart Support");
            mail.To.Add(new MailAddress(user.login));
            mail.Body = "Dear " + user.firstName + " " + user.lastName + ", Your account on HRSmart has been abled.You can use again our HRSmart.";
            SmtpClient SMTPServer = new SmtpClient("smtp.live.com", 587);


            SMTPServer.Credentials = new System.Net.NetworkCredential("HRSmart@outlook.fr", "Beyrem2016");
            SMTPServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SMTPServer.EnableSsl = true;
            try
            {
                SMTPServer.Send(mail);
            }
            catch (Exception e)
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
        public ActionResult IndexHR()
        {
            ApplicationUser user =
    System.Web.HttpContext.Current.GetOwinContext()
        .GetUserManager<ApplicationUserManager>()
        .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            ViewBag.users = serviceuserbuisness.getMyEmployees(user.userId);
            
            return View();
        }

        public ActionResult StatisticHR()
        {
            ApplicationUser user =
                System.Web.HttpContext.Current.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>()
                    .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            ViewBag.popularskill = serviceuserbuisness.getMostPopularSkill(serviceuserbuisness.getMyEmployees(user.userId));
            ViewBag.averagesalary = serviceuserbuisness.getAverageSalaries();
            ViewBag.averageage = serviceuserbuisness.getAverageAgeOfEmployess();
            ViewBag.bestEmployee = serviceuserbuisness.getBestEmployee();
            return View();
        }

    }
}
