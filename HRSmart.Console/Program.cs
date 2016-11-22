using HRSmart.data.Models;
using HRSmart.Domain.Entities;
using HRSmart.Service.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiAiSDK;
using ApiAiSDK.Model;

namespace HRSmart.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Console.WriteLine("here1");
            //mysqlpiContext mc = new mysqlpiContext();


            //buisness b = new buisness();
            //b.name = "test final";
            /*mc.buisnesses.Add(b);
            mc.SaveChanges();*/
            //IServiceBusiness service = new ServiceBusiness();
            //service.Add(b);
            //service.commit();
            //System.Console.WriteLine("here2");
            //System.Console.Read();

            ApiAi ai;
            var config = new AIConfiguration("2b4219f782904d6a996efcc54b5742fe", SupportedLanguage.English);
            ai = new ApiAi(config);
            
            while (true)
            {
                System.Console.WriteLine("Say something");
                string input = System.Console.ReadLine();
                if(input == "0") break;
                var response = ai.TextRequest(input);
                System.Console.WriteLine(response.Result.Fulfillment.Speech);
                if (response.Result.GetStringParameter("subject") != "" &&
                    response.Result.GetStringParameter("description") != "")
                {
                    System.Console.WriteLine("subject : " + response.Result.GetStringParameter("subject"));
                    System.Console.WriteLine("description : " + response.Result.GetStringParameter("description"));
                    break;
                }
                
            }
            System.Console.ReadLine();


        }
    }
}
