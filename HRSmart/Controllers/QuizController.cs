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
        
        private IServiceQuestion squ = new ServiceQuestion();
        private IServiceAssessment sa = new ServiceAssessment();
        // GET: Quiz
        public ActionResult Index()
        {
            IDictionary<string,int> assoc = new Dictionary<string,int>();
            IDictionary<string, int> AverageQuizResults = new Dictionary<string, int>();
            IEnumerable<question> questions = squ.GetMany().ToList();
            var assessments = sa.GetMany().ToList().GroupBy(a => a.quiz);

            foreach (question question in questions)
            {
                List<quiz> qzz = question.quizs.ToList();
                assoc[question.body] = (qzz.Count*100/ questions.Count());
            }
            foreach (var group in assessments)
            {
                var groupKey = group.Key;
                int average = 0;
                foreach (var groupedItem in group)
                    average += groupedItem.result;
                average /= group.Count();
                AverageQuizResults[groupKey.description] = average * 5;
            }

            ArrayList colorList = new ArrayList { "#2196F3", "#FF9800", "#4CAF50" , "#F44336", "#9C27B0", "#3F51B5", "#CDDC39" };
            ViewBag.colors = colorList;
            ViewBag.MostUsedQuestions = assoc;
            ViewBag.AverageQuizResults = AverageQuizResults;
            return View();
        }
    }
}