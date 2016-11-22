using HRSmart.Domain.Entities;
using HRSmart.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSmart.Service.Business
{
    public interface IServiceUser : IMyServiceGeneric<user>
    {
        float getNumberOfEmployedUsers();
        float getAverageNumberOfSkillsUser();
        List<int> getUserPerMonth();
        int getNumberofHR();
        
       
    }
}
