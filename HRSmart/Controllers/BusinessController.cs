using HRSmart.Domain.Entities;
using HRSmart.Service.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using WebGrease.Css.Extensions;

namespace HRSmart.Controllers
{
    public class BusinessController : Controller
    {
        private IServiceBusiness bu = new ServiceBusiness();

        // GET: Business
        public ActionResult Index()
        {
            List<buisness> buisnesses = bu.GetMany().ToList();
            ViewBag.buisness = buisnesses;
            return View();
        }

        public ActionResult DesBusiness()
        {
            List<buisness> buisnesses = bu.getInvalidatedBusiness();
            ViewBag.buisness = buisnesses;
            return View();
        }

        public ActionResult Statistique()
        {
            Dictionary<int, int> usersPerMonth = bu.getNbUsersPerMonth();
            Dictionary<int, int> usersPostulPerMonth = bu.getNbPostulationsPerMonth();
            ViewBag.usersPerMonth = usersPerMonth;
            ViewBag.usersPostulPerMonth = usersPostulPerMonth;
            return View();
        }

        public ActionResult Address(int id)
        {
            ViewBag.addresses = bu.GetById(id).Address.ToList();
            ViewBag.idBusiness = bu.GetById(id).Address.ToList()[0].buisness_id;
            return View();
        }

        public ActionResult Active(int id)
        {
            buisness buisness = bu.GetById(id);
            buisness.valid = true;
            bu.commit();
            return RedirectToAction("DesBusiness", "Business");
        }

        // GET: Business/Details/5
        public ActionResult Details(int id)
        {
            buisness b = new buisness();
            b = bu.GetById(id);
            ViewBag.business = b;
            ViewBag.nbUsers = b.Users.Count();
            ViewBag.nbStages = b.Stages.Count();
            ViewBag.nbJobs = b.Jobs.Count();
            ViewBag.sommeSal = bu.getSumSalary(b.id);
            ViewBag.bestEmpl = bu.getBestEmpByBusiness(b.id);
            return View();
        }

        // GET: Business/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Business/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Business/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Business/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Business/Delete/5
        public ActionResult Delete(int id)
        {
            buisness buisness = bu.GetById(id);
            return View(buisness);
        }

        // POST: Business/Delete/5
        [HttpPost , ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            buisness buisness = bu.GetById(id);
            bu.Delete(buisness);
            bu.commit();
            return RedirectToAction("DesBusiness", "Business");
        }
    }
}
