using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSmart.data.Infrastructure;
using HRSmart.Domain.Entities;
using HRSmart.ServicePattern;

namespace HRSmart.Service.Business
{
    public class ServiceSkill : MyServiceGeneric<skill>, IServiceSkill
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();
        private static IUnitOfWork itw = new UnitOfWork(dbfac);

        public ServiceSkill() : base(itw)
        {
        }

        public IDictionary<skill, int> getPopularByJob()
        {
            List<skill> skills = this.GetMany().ToList();
            IDictionary<skill,int> skillDictionary = new Dictionary<skill, int>();

            foreach (skill skill in skills)
            {
                int count = itw.getRepository<jobskill>().GetMany(js => js.skill.id == skill.id).Count();
                skillDictionary.Add(skill,count);
            }

            return skillDictionary;
        }

        public IDictionary<skill, int> getPopularByUser()
        {
            List<skill> skills = this.GetMany().ToList();
            IDictionary<skill,int> skillDictionary = new Dictionary<skill, int>();

            foreach (skill skill in skills)
            {
                int count = itw.getRepository<userskill>().GetMany(js => js.skill.id == skill.id).Count();
                skillDictionary.Add(skill, count);
            }
            return skillDictionary;
        }

        public decimal getSkillPopularity(int id)
        {
            int count = 0;
            int sum = 0;
            foreach (KeyValuePair<skill, int> keyValuePair in this.getPopularByJob())
            {
                sum += keyValuePair.Value;
                if (keyValuePair.Key.id == id)
                {
                    count += keyValuePair.Value;

                }
            }
            foreach (KeyValuePair<skill, int> keyValuePair in this.getPopularByUser())
            {
                sum += keyValuePair.Value;
                if (keyValuePair.Key.id == id)
                {
                    count += keyValuePair.Value;

                }
            }
            
            return count;
        }

        public IDictionary<DateTime, int> getDemand(skill skill)
        {
            int count = 0;
            IDictionary<DateTime,int> demandDictionary = new Dictionary<DateTime, int>();
            //List<jobskill> jobskills =
            //    itw.getRepository<jobskill>()
            //        .GetMany(js => js.joboffer.creationDate.Day > DateTime.Today.Day - 30)
            //        .ToList();
            IEnumerable<IGrouping<DateTime, jobskill>> query = itw.getRepository<jobskill>()
                .GetMany(js => js.joboffer.creationDate.Day > DateTime.Today.Day)
                .GroupBy(jobskill =>jobskill.joboffer.creationDate);

            foreach (IGrouping<DateTime, jobskill> jobskills in query)
            {
                foreach (jobskill jobskill in jobskills)
                {
                    if (jobskill.skill.id == skill.id)
                    {
                        demandDictionary.Add(jobskills.Key,jobskills.Count());
                    }
                }
            }
            return demandDictionary;
        }
    }
}
