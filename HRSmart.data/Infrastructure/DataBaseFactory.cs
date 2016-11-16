using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSmart.data.Models;
using DS.data.Infrastructures;

namespace HRSmart.data.Infrastructure
{
    public class DataBaseFactory : Disposable, IDataBaseFactory
    {
        private mysqlpiContext context;
        public mysqlpiContext MyContext { get { return context; } }

        public DataBaseFactory()
        {
            this.context = new mysqlpiContext();
        }

        protected override void DisposeCore()
        {
            if (MyContext != null)
                MyContext.Dispose();
        }
    }
}
