using HRSmart.Domain.Entities;
using HRSmart.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSmart.Service.Business
{
   public interface IServiceUserBuisness : IMyServiceGeneric<userbuisness>
    {
        List<userbuisness> findByuser(int id);
        List<userbuisness> findBybuisness(int id);
        List<user> getMyEmployees(int id);

        skill getMostPopularSkill(List<user> users);
        float getAverageSalaries();
        float getAverageAgeOfEmployess();

        user getBestEmployee();
    }
}
