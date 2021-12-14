using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Fak4ura.Models
{
    public class UpdateUserData:DbConnection
    {
        public UpdateUserData() { }
        public UpdateUserData(string haslo, string salt, string userIdentifier)
        {
            update = $"UPDATE F4_Uzytkownicy SET " +
                $"haslo = '{haslo}' , sol = '{salt}' WHERE uzytkownik_id = '{userIdentifier}'";
            result = insertData(update);
        }

        public UpdateUserData(dynamic obj, string userIdentifier)
        {
           
            update = "UPDATE F4_Uzytkownicy SET " +
            $" imie = '{obj.Imie}' , nazwisko = '{obj.Nazwisko}' , nazwa_firmy = '{obj.NazwaFirmy}' , email = '{obj.Email}' " +
            $" ,ulica = '{obj.Ulica}' , kod_pocztowy = '{obj.KodPocztowy}' , miejscowosc = '{obj.Miejscowosc}' , nip = '{obj.Nip}' " +
            $" ,telefon = '{obj.Telefon}' , bank = '{obj.Bank}' , numer_konta = '{obj.NumerKonta}' " +
            $"WHERE uzytkownik_id = '{userIdentifier}'";
            
            result = insertData(update);
        }
       
        
        public string update { get; set; }
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
                return "⛌ "+ex.Message;
            }
            finally
            {
                oracleConn.Close();
            }
            Console.WriteLine("@---->insertData: Success");
            return "✓ Powodzenie";
        }





        //ALTERNATIVE VERSION
        private string insertData2(string haslo, string userIdentifier)
        {
            var oracleConn = new OracleConnection(ConnString);
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = oracleConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE F4_Uzytkownicy SET haslo = ':newHaslo' WHERE email = ':userIdentifier'";
           
            cmd.Parameters.Add("newHaslo", OracleDbType.Varchar2).Value = haslo;
            cmd.Parameters.Add("userIdentifier", OracleDbType.Varchar2).Value = userIdentifier;

            try
            {
                oracleConn.Open();
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
