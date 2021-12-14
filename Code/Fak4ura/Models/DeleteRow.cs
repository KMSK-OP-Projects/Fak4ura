using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fak4ura.Models
{
    public class DeleteRow : DbConnection
    {
        public DeleteRow() { }
        public DeleteRow(string table, string id)
        {
            SqlQuery = $"DELETE FROM {table}  WHERE id = '{id}'";
            Result = removeRow();
        }

        public string SqlQuery { get; set; }
        public string Result { get; set; }

        private string removeRow()
        {
            var oracleConn = new OracleConnection(ConnString);
            try
            {
                oracleConn.Open();
                OracleCommand cmd = new OracleCommand(SqlQuery, oracleConn);
                //await Task.Run(() => cmd.ExecuteNonQuery());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("@---->deleteData: " + ex.Message);
                return "⛌ " + ex.Message;
            }
            finally
            {
                oracleConn.Close();
            }
            Console.WriteLine("@---->deleteData: Success");
            return "✓ Powodzenie";
        }
    }

    
}
