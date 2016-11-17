using HRSmart.Service.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRSmart.Domain.Entities;

namespace HRSmart.Controllers
{
    public class CertificatController : Controller
    {
        private IServiceCertificat serviceCertificat = null;
        public CertificatController()
        {
            serviceCertificat = new ServiceCertificat();
        }
        // GET: Certificat
        public ActionResult Index()
        {
            var certificats = serviceCertificat.GetMany().ToList();

            return View(certificats);
        }

        // GET: Certificat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Certificat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Certificat/Create
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

        // GET: Certificat/Edit/5
        public ActionResult Edit(int id)
        {

            var edited = serviceCertificat.GetById(id);
            return View(edited);
        }

        // POST: Certificat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,certificat c)
        {
            certificat cc = serviceCertificat.GetById(id);
            try
            {
                if (ModelState.IsValid)
                {
                    cc.name = c.name;
                    cc.skill_id = c.skill_id;
                    serviceCertificat.Update(cc);
                    serviceCertificat.commit();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Certificat/Delete/5
        public ActionResult Delete(int id)
        {

            var del = serviceCertificat.GetById(id);
            return View(del);
        }

        // POST: Certificat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                serviceCertificat.Delete(serviceCertificat.GetById(id));
                serviceCertificat.commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
