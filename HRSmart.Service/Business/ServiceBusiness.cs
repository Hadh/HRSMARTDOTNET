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
    public class ServiceBusiness: MyServiceGeneric<buisness>, IServiceBusiness
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();
        private static IUnitOfWork utw = new UnitOfWork(dbfac);
        public ServiceBusiness() : base(utw)
        {

        }

        public List<buisness> getInvalidatedBusiness()
        {
           List<buisness> result = new List<buisness>();
           foreach(buisness b in utw.getRepository<buisness>().GetMany())
            {
                if (b.valid == false)
                {
                    result.Add(b);
                }
            }
            return result;
        }

        public float getSumSalary(int id)
        {
            buisness buisnesses = utw.getRepository<buisness>().GetById(id);
            float sum = 0;
            foreach (var u in buisnesses.Users)
            {
                sum += u.salary;
            }
            return sum;
        }

        public user getBestEmpByBusiness(int id)
        {
            buisness buisnesses = utw.getRepository<buisness>().GetById(id);
            Dictionary<userbuisness, float> result = new Dictionary<userbuisness, float>();
            foreach (userbuisness u in buisnesses.Users)
            {
                float sumReward = 0;
                foreach (postulation p in u.user.postulations)
                {
                    sumReward += p.reward.value;
                }
               result.Add(u,sumReward);   
            }
            float max = 0;
            user user = new user();
            foreach (KeyValuePair<userbuisness, float> entry in result)
            {
                if (entry.Value > max)
                {
                    max = entry.Value;
                    user = entry.Key.user;
                }
            }
            return user;
        }

        public Dictionary<int, int> getNbPostulationsPerMonth()
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            
            for (int i = 1; i <= DateTime.Now.Month; i++)
              {
                int sommePostulations = 0;
                foreach (postulation p in utw.getRepository<postulation>().GetMany().ToList())
                {
                    if ((p.datePostulation.Value.Month == i) && (p.datePostulation.Value.Year == DateTime.Now.Year))
                    {
                        sommePostulations += 1;
                    }
               }
                result.Add(i, sommePostulations);
            }
            return result;
        }

        public Dictionary<int,int> getNbUsersPerMonth()
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            List<userbuisness> users;

            for (int i = 1; i <= DateTime.Now.Month; i++)
            {
                users = new List<userbuisness>();
                foreach (userbuisness ub in utw.getRepository<userbuisness>().GetMany().ToList())
                {
                    if ((ub.hireDate.Value.Month == i) && (ub.hireDate.Value.Year == DateTime.Now.Year))
                    {
                        users.Add(ub);
                    }
                }
                result.Add(i, users.Count());
            }
            return result;
        }
    }
}
