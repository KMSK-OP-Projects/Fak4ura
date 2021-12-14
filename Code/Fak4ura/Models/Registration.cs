using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fak4ura.Models
{
    public class Registration: DbConnection
    {
        public Registration() { }
        public Registration(string imie, string nazwisko, string email, string haslo)
        {
            insert = "INSERT INTO F4_Uzytkownicy(imie, nazwisko, haslo, email) VALUES " +
            $"('{imie}','{nazwisko}', '{haslo}' ,'{email}')";
            result = insertData(insert);
        }
        public string insert { get; set; }
        public string result { get; set; }



        private string insertData(string sqlQuery)
        {
            var oracleConn = new OracleConnection(ConnString);
            try
            {
                oracleConn.Open();
                OracleCommand cmd = new OracleCommand(sqlQuery, oracleConn);
                //await Task.Run(() => cmd.ExecuteNonQuery());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("@---->insertData: " + ex.Message);
                return ex.Message;
            }
            finally
            {
                oracleConn.Close();
            }
            Console.WriteLine("@---->insertData: Success");
            return "✓ Dodano użytkownika";
        }
    }
}
