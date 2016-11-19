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
                // b.
            }
            return result;
        }
    }
}
