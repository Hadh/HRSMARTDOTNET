using HRSmart.data.Infrastructure;
using HRSmart.Domain.Entities;
using HRSmart.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Specialized;

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
            while (counter < number && jobs.Count > 0)
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
                if (counter == jobs.Count + 1) { break; }
            }
            return ret;
        }
        public float getAverageJobSalary(joboffer job)
        {

            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["job"] = JsonConvert.SerializeObject(job);

                var response = client.UploadValues("http://localhost:18080/HRSmart-web/rest/job/salary", values);

                var responseString = Encoding.Default.GetString(response);

                return float.Parse(responseString);
            }

            //string sURL;
            //sURL = "http://localhost:18080/HRSmart-web/rest/job/1";
            //WebRequest wrGETURL;
            //wrGETURL = WebRequest.Create(sURL);

            //WebProxy myProxy = new WebProxy("myproxy", 80);
            //myProxy.BypassProxyOnLocal = true;

            //wrGETURL.Proxy = WebProxy.GetDefaultProxy();


            //Stream objStream;
            //objStream = wrGETURL.GetResponse().GetResponseStream();

            //StreamReader objReader = new StreamReader(objStream);
            //string sLine = "";
            //int i = 0;
            //string final = "";
            //while (sLine != null)
            //{
            //    i++;
            //    sLine = objReader.ReadLine();
            //    if (sLine != null)
            //    {
            //        final = final + sLine;

            //    }
            //}



        }
    }
}
