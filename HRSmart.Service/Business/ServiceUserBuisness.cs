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
    }
}
