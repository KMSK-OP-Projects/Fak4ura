using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Fak4ura.Database.Interfaces
{
    internal interface IDbConnectionManager
    {
        public IDbConnection CreateDatabaseConnection();
    }
}
