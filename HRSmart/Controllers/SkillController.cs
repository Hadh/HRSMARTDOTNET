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

            return View();
        }

    }
}