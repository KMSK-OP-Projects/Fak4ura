using Fak4ura.Database.Interfaces;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Fak4ura.Database
{
    internal class OracleDbConnectionManager : IDbConnectionManager
    {
        private Startup.ConnectionStrings _connectionStrings;
        public OracleDbConnectionManager(Startup.ConnectionStrings connectionStrings)
        {
            this._connectionStrings = connectionStrings;

        }
        public IDbConnection CreateDatabaseConnection() => new OracleConnection(_connectionStrings.OracleDatabase);
    }
}
