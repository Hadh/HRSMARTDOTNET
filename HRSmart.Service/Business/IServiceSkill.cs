using HRSmart.Domain.Entities;
using HRSmart.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HRSmart.Service.Business
{
    public interface IServiceSkill : IMyServiceGeneric<skill>
    {
        IDictionary<skill, int> getPopularByJob();
        IDictionary<skill, int> getPopularByUser();
        decimal getSkillPopularity(int id);
    }
}
