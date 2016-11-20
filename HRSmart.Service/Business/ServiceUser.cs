using HRSmart.Domain.Entities;
using HRSmart.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSmart.data.Infrastructure;

namespace HRSmart.Service.Business
{
   public class ServiceUser : MyServiceGeneric<user>, IServiceUser
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();
        private static IUnitOfWork utw = new UnitOfWork(dbfac);
        IServiceUserBuisness serviceuserbuisness = new ServiceUserBuisness();
        IServiceUserSkill serviceuserskill = new ServiceUserSkill();
        public ServiceUser() : base(utw)
        {
        }

        public float getNumberOfEmployedUsers()
        {
            List<user> users = this.GetMany().ToList();
            float counter=0;
            foreach (var u in users)
            {
              

                foreach (var ub in serviceuserbuisness.findByuser(u.id))
                {
                   
                    if (ub.role == "HR")
                    {
                       
                     
                        counter++;
                        break;

                    }
                    if (ub.role == "RM")
                    {
                       
                       
                        counter++;
                        break;
                    }
                    if (ub.role == "EMP")
                    {
                  
                        counter++;
                        break;
                    }

                }
                

            }

            return counter;
        }

        public float getAverageNumberOfSkillsUser()
        {
            List<user> users = this.GetMany().ToList();
            float nbskills = 0;
            foreach (var u in users)
            {
                    nbskills+= u.userskills.ToList().Count;
                
            }
            return nbskills/users.Count;
        }

        public List<int> getUserPerMonth()
        {
            List<int> li = new List<int>();
           
            for (int i = 0; i < 6; i++)
            {
                DateTime mon1 = DateTime.Now.Subtract((DateTime.Now.AddMonths(i) - DateTime.Now));
                DateTime mon2 = DateTime.Now.Subtract((DateTime.Now.AddMonths(i+1) - DateTime.Now));
                li.Add(this.GetMany(x =>
                (DateTime.Compare(x.dateInscription, mon1 ) < 0)
                && (DateTime.Compare(x.dateInscription, mon2) >= 0)
                )
                .ToList().Count);
            }
            return li;
        }
    }
}
