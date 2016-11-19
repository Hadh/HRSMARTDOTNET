using HRSmart.Domain.Entities;
using HRSmart.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSmart.data.Infrastructure;

namespace HRSmart.Service.Business
{
    public class ServiceUserSkill : MyServiceGeneric<userskill>, IServiceUserSkill
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();
        private static IUnitOfWork utw = new UnitOfWork(dbfac);
        public ServiceUserSkill() : base(utw)
        {

        }

        public List<userskill> findByuser(int id)
        {
            return this.GetMany(u => u.user_id == id).ToList();
        }
    }
}
