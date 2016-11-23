﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSmart.data.Infrastructure;
using HRSmart.Domain.Entities;
using HRSmart.ServicePattern;

namespace HRSmart.Service.Business
{
    public class ServiceCertificat : MyServiceGeneric<certificat>, IServiceCertificat
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();
        private static IUnitOfWork itw = new UnitOfWork(dbfac);

        public ServiceCertificat() : base(itw)
        {
        }

       
    }
}
