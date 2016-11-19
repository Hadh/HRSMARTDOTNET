using HRSmart.Domain.Entities;
using HRSmart.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSmart.Service.Business
{
    public interface IServiceJobOffer : IMyServiceGeneric<joboffer>
    {
        float getAverageSalary();
        float getPercentageAvailableJobs();
        int getNumberOfPostulations(int id);
        List<joboffer> getMostPopularJobs(int number);
        joboffer getAverageJobSalary(joboffer job);
    }
}
