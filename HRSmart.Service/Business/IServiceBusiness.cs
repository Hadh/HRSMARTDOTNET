using HRSmart.Domain.Entities;
using HRSmart.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSmart.Service.Business
{
    public interface IServiceBusiness : IMyServiceGeneric<buisness>
    {
        List<buisness> getInvalidatedBusiness();
        float getSumSalary(int id);
        user getBestEmpByBusiness(int id);
        Dictionary<int, int> getNbPostulationsPerMonth();
        Dictionary<int, int> getNbUsersPerMonth();
    }
}
