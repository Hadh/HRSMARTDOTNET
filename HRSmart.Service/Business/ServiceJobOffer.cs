using HRSmart.data.Infrastructure;
using HRSmart.Domain.Entities;
using HRSmart.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSmart.Service.Business
{
    public class ServiceJobOffer : MyServiceGeneric<joboffer>, IServiceJobOffer
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();
        private static IUnitOfWork utw = new UnitOfWork(dbfac);
        public ServiceJobOffer() : base(utw)
        {

        }
        public float getAverageSalary()
        {
            List<joboffer> jobs = this.GetMany().ToList();
            float average = 0;
            foreach (var j in jobs)
            {
                average += j.salary;
            }
            return average / jobs.Count;
        }
        public float getPercentageAvailableJobs()
        {
            List<joboffer> jobs = this.GetMany().ToList();
            float counter = 0;
            foreach (var j in jobs)
            {
                if (j.active)
                {
                    counter++;
                }
            }
            return (counter / jobs.Count) * 100;
        }
        public int getNumberOfPostulations(int id)
        {
            joboffer job = this.GetById(id);
            int counter = 0;
            foreach (var r in job.rewards)
            {
                counter += r.postulations.Count;
            }
            return counter;
        }

        public List<joboffer> getMostPopularJobs(int number)
        {
            List<joboffer> jobs = this.GetMany().ToList();
            List<joboffer> ret = new List<joboffer>();
            int counter = 0;
            while (counter < number)
            {
                joboffer max = jobs.ElementAt(0);
                for (int i = 0; i < jobs.Count - (counter); i++)
                {
                    Console.WriteLine(jobs.ElementAt(i));
                    if (this.getNumberOfPostulations(jobs.ElementAt(i).id) > this.getNumberOfPostulations(max.id))
                    {
                        max = jobs.ElementAt(i);

                    }
                }
                ret.Add(max);
                jobs.Remove(max);
                counter++;
                if (counter == jobs.Count) { break; }
            }
            return ret;
        }
    }
}
