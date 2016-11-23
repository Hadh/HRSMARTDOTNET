using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRSmart.Domain.Entities;
using HRSmart.Service.Business;
namespace HRSmart.Controllers
{
    public class SkillController : Controller
    {
        private IServiceSkill serviceSkill = new ServiceSkill();
        private IServiceUserSkill userSkill = new ServiceUserSkill();
        private  IServiceJobSkill jobSkill = new ServiceJobSkill();

        // GET: Skill
        public ActionResult Index()
        {
            List<skill> skills = serviceSkill.GetMany().ToList();
            IDictionary<skill,decimal> skillFloats = new Dictionary<skill, decimal>();
            foreach (skill skill in skills)
            {
                decimal rank = serviceSkill.getSkillPopularity(skill.id);
                skillFloats.Add(skill,rank);
            }
            ViewBag.skillfloats = skillFloats;
           
            ArrayList colorList = new ArrayList { "#2196F3", "#FF9800", "#4CAF50", "#F44336", "#9C27B0", "#3F51B5", "#CDDC39" , "#3949AB", "#FF8F00", "#651FFF", "#d32f2f" };
            ViewBag.colors = colorList;

            IDictionary<skill, int> skillDictionaryjob = serviceSkill.getPopularByJob();
            ViewBag.skilldictjob = skillDictionaryjob;
            IDictionary<skill, int> skillDictionaryuser = serviceSkill.getPopularByUser();
            ViewBag.skilldictuser = skillDictionaryuser;

            foreach (skill skill in skills)
            {
                ViewData.Add("skilldemand"+skill.id.ToString(),serviceSkill.getDemand(skill));
            }

            return View();
        }

        public ActionResult Add()
        {

            return View();
        }
        public ActionResult SaveUploadedFile()
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {

                        var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\WallImages", Server.MapPath(@"\")));

                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "imagepath");

                        var fileName1 = Path.GetFileName(file.FileName);

                        bool isExists = System.IO.Directory.Exists(pathString);

                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);

                        var path = string.Format("{0}\\{1}", pathString, file.FileName);
                        string skillname = Request.Form["skillname"];
                        skill skill = new skill(skillname,fileName1);
                        serviceSkill.Add(skill);
                        serviceSkill.commit();
                        file.SaveAs(path);

                    }

                }

            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }


            if (isSavedSuccessfully)
            {
                return View("Index");
            }
            else
            {
                ViewBag.error = "Error in saving file";
                return View("Add");

            }
        }

    }
}