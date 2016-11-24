using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRSmart.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace HRSmart.Controllers
{
   [Authorize]
    public class HomeController : Controller
    {
        public  ActionResult Index()
        {
          //  var user = System.Web.HttpContext.Current.User.Identity.Name;
            ApplicationUser user =
                System.Web.HttpContext.Current.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>()
                    .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewBag.firstName = user.FirstName;
            if (user.Roles.ElementAt(0).RoleId == "1")
            {
                return RedirectToAction("Statistics","User");
            }
            else
            {
                return RedirectToAction("Index", "Business");
            }

         
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}