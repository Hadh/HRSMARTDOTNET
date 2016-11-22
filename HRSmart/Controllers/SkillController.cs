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
            ViewBag.skills = skills;
            ArrayList colorList = new ArrayList { "#2196F3", "#FF9800", "#4CAF50", "#F44336", "#9C27B0", "#3F51B5", "#CDDC39" };
            ViewBag.colors = colorList;

            IDictionary<String, int> skillDictionary = new Dictionary<string, int>();

            List<int> freq = new List<int>() { 5, 4, 7, 8 };
            // skills.ForEach(delegate(skill skill) { skillDictionary.Keys.Add(skill.name); });
            // 
            // freq.ForEach(delegate(int f) {skillDictionary.Values.Add(f);} );
            //ViewBag.skilldic = skillDictionary;

            foreach (skill skill in skills)
            {
                
            }
            
            


            return View();
        }

    }
}