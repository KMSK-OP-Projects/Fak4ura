using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fak4ura.Models
{
    public class UpdateCounterPartyData:DbConnection
    {
        public UpdateCounterPartyData(){}
        public UpdateCounterPartyData(dynamic obj)
        {
            var update = "UPDATE F4_Kontrahenci SET " +
            $" nazwa = '{obj.NazwaFirmy}' , imie = '{obj.Imie}' , nazwisko = '{obj.Nazwisko}' , email = '{obj.Email}', " +
            $" ulica = '{obj.Ulica}' , kod_pocztowy = '{obj.KodPocztowy}' , nip = '{obj.Nip}' , miejscowosc = '{obj.Miejscowosc}' , " +
            $" telefon = '{obj.Telefon}' , www = '{obj.WWW}' WHERE id = {int.Parse(obj.Id)}";

            Result = insertData(update);
        }



        public string Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NazwaFirmy { get; set; } //nazwa
        public string Ulica { get; set; }
        public string KodPocztowy { get; set; }
        public string Miejscowosc { get; set; }  
        public string Kraj { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }  
        public string Nip { get; set; }
        public string WWW { get; set; }
        public string insert { get; set; }
        public string Result { get; set; }



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
                return "⛌ " + ex.Message;
            }
            finally
            {
                oracleConn.Close();
            }
            Console.WriteLine("@---->insertData: Success");
            return "✓ Powodzenie";
        }




    }
}
