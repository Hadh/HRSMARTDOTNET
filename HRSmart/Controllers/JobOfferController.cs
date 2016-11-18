using HRSmart.Domain.Entities;
using HRSmart.Service.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRSmart.Controllers
{
    public class JobOfferController : Controller
    {
        private ServiceJobOffer jobService = new ServiceJobOffer();
        // GET: JobOffer
        public ActionResult Index()
        {
            List<joboffer> jobs = jobService.GetMany().ToList();
            ViewBag.jobs = jobs;
            return View();
        }

        // GET: JobOffer/Details/5
        public ActionResult Details(int id)
        {
            joboffer job = jobService.GetById(id);
            ViewBag.job = job;
            ViewBag.numPostulations = jobService.getNumberOfPostulations(job.id);
            return View();
        }

        public ActionResult Switch(int id)
        {
            joboffer job = jobService.GetById(id);
            if (job.active == true)
            {
                job.active = false;
            }
            else
            {
                job.active = true;

            }
            jobService.commit();
            return RedirectToAction("Index", "JobOffer");
        }
        public ActionResult JobsAnalytics()
        {
            ViewBag.available = jobService.getPercentageAvailableJobs();
            ViewBag.popular = jobService.getMostPopularJobs(5);
            return View();
        }
        public ActionResult JobAnalytics()
        {
            ViewBag.available = jobService.getPercentageAvailableJobs();
            return View();
        }
    }
}
