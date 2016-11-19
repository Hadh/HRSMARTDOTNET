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
    public class ServiceJobSkill : MyServiceGeneric<jobskill>, IServiceJobSkill
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();
        private static IUnitOfWork utw = new UnitOfWork(dbfac);
        public ServiceJobSkill() : base(utw)
        {

        }

        public skill getMostPopular()
        {
            ServiceSkill ss = new ServiceSkill();
            List<skill> skills = ss.GetMany().ToList();
            skill max = skills.ElementAt(0);
            foreach (var s in skills)
            {
                if (max.jobskills.Count < s.jobskills.Count)
                {
                    max = s;
                }
            }
            return max;
        }
    }
}
