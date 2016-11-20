using HRSmart.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSmart.data.Infrastructure;
using HRSmart.Domain.Entities;
using System.Collections;

namespace HRSmart.Service.Business
{
    public class ServiceUserBuisness : MyServiceGeneric<userbuisness>, IServiceUserBuisness
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();
        private static IUnitOfWork utw = new UnitOfWork(dbfac);
        public ServiceUserBuisness() : base(utw)
        {
        }

        public List<userbuisness> findByuser(int id)
        {
            return this.GetMany(u => u.user_id == id).ToList();
        }

        public List<userbuisness> findBybuisness(int id)
        {
            return this.GetMany(u => u.buisness_id == id).ToList();
        }

        public List<user> getMyEmployees()
        {
            ServiceUser serviceuser = new ServiceUser();
           
            user user = serviceuser.GetById(2);
            buisness buisness = this.GetMany(ub => (ub.user.id == user.id) && (ub.role == "HR")).ToList().ElementAt(0).buisness;
            List<userbuisness> userbuisness = this.findBybuisness(buisness.id).ToList();

            List<user> users = new List<user>();
            foreach (var ub in userbuisness)
            {
                if (ub.role == "RM")
                {
                    ub.user.role = "Recruiter Manager";
                    users.Add(ub.user);
                    break;
                }
                if (ub.role == "EMP")
                {
                    ub.user.role = "Employee";
                    users.Add(ub.user);
                    break;
                }


            }
            return users;

        }

        public skill getMostPopularSkill(List<user> users)
        {
            skill max = new skill();
            int maxcounter = 0;
            ServiceUserSkill serviceuserskill = new ServiceUserSkill();
            List<skill> skills = serviceuserskill.getFromUsers(users);
            foreach (var s in skills)
            {
                int counter = 0;
                foreach (var u in users)
                {
                    foreach (var us in u.userskills)
                    {
                        if (us.skill.id == s.id)
                        {
                            counter++;
                        }
                    }
                }
                if(maxcounter <= counter)
                {
                    maxcounter = counter;
                    max = s;
                }

            }
            return max;
        }

        public float getAverageSalaries()
        {
          
            float sumSalaries=0;
            ServiceUser serviceuser = new ServiceUser();
            List<user> users = serviceuser.GetMany().ToList();
            foreach (var u in users)
            {
                foreach (var ub in u.userbuisnesses)
                {
                    sumSalaries += ub.salary;
                }
            }
            return sumSalaries / users.Count;
        }

        public float getAverageAgeOfEmployess()
        {
            float sumAge = 0;
            ServiceUser serviceuser = new ServiceUser();
            List<user> users = serviceuser.GetMany().ToList();
            foreach (var u in users)
            {
                foreach (var ub in u.userbuisnesses)
                {
                    sumAge += ub.user.age;
                }
            }
            return sumAge / users.Count;

        }
    }
}
