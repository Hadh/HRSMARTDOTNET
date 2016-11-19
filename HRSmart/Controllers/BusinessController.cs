using HRSmart.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRSmart.Controllers
{
    public class BusinessController : Controller
    {

        // GET: Business
        public async Task<ActionResult> Index()
        {
            string url = "http://localhost:18080/HRSmart-web/rest/buisness/1";

            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.Http.HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonMessage;
                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    }

                    buisness tokenResponse = (buisness)JsonConvert.DeserializeObject(jsonMessage, typeof(buisness));

                    ViewBag.buisness = tokenResponse;
                }
            }
            return View();
        }

        // GET: Business/Details/5
        public ActionResult Details(int id)
        {
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
            return View();
        }

        // POST: Business/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
