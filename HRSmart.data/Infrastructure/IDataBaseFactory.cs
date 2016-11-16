using HRSmart.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSmart.data.Infrastructure
{
    public interface IDataBaseFactory
    {
        mysqlpiContext MyContext { get; }
    }
}
