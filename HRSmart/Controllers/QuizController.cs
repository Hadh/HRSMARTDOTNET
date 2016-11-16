using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRSmart.Domain.Entities;
using HRSmart.Service.Business;

namespace HRSmart.Controllers
{
    public class QuizController : Controller
    {
        private IServiceQuiz sq = new ServiceQuiz();
        private IServiceQuestion squ = new ServiceQuestion();
        
        // GET: Quiz
        public ActionResult Index()
        {
            IDictionary<string,int> assoc = new Dictionary<string,int>();
            IEnumerable<question> questions = squ.GetMany();
            foreach (question question in questions)
            {
                assoc[question.body] = question.quizs.Count;
            }
            ViewBag.Data = assoc; 
            return View();
        }
    }
}