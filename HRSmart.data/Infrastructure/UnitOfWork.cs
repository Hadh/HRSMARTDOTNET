using HRSmart.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSmart.data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private mysqlpiContext context;
        IDataBaseFactory dbfac;

        public UnitOfWork(IDataBaseFactory dbfac)
        {
            this.dbfac = dbfac;
            context = dbfac.MyContext;
        }

        public void commit()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public IRepositoryBase<T> getRepository<T>() where T : class
        {
            return new RepositoryBase<T>(context);
        }
    }
}
