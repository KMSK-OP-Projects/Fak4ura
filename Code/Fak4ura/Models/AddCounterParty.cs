using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fak4ura.Models
{
    public class AddCounterParty : DbConnection
    {
        public AddCounterParty() { }
        public AddCounterParty(AddCounterParty obj)
        {
            insert = "INSERT INTO F4_Kontrahenci(nazwa, imie, nazwisko, ulica, kod_pocztowy, nip , email, www, miejscowosc, telefon, uzytkownik_id) VALUES " +
            $"('{obj.NazwaFirmy}','{obj.Imie}', '{obj.Nazwisko}' ,'{obj.Ulica}'," +
            $"'{obj.KodPocztowy}','{obj.Nip}','{obj.Email}','{obj.WWW}', '{obj.Miejscowosc}', '{obj.Telefon}', '{obj.Uzytkownik_id}')";
            result = insertData(insert);
        }


        public string Id { get; set; }
        public string Uzytkownik_id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NazwaFirmy { get; set; } //nazwa
        public string Ulica { get; set; }
        public string KodPocztowy { get; set; }
        public string Miejscowosc { get; set; } //brak
        public string Kraj { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; } //brak
        public string Nip { get; set; }
        public string WWW { get; set; }
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
            return "✓ Dodano kontrahenta";
        }
    }
}
