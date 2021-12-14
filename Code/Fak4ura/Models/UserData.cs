using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fak4ura.Models
{
    public class UserData: DbConnection
    {

        public UserData() { }
       
        public UserData(string login)
        {
            getUserData(login);
        }
        public string UzytkownikId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NazwaFirmy { get; set; }
        public string Nazwisko_rodowe{ get; set; }
        public string Haslo { get; set; }
        public string Ulica { get; set; }
        public string KodPocztowy { get; set; }
        public string Miejscowosc { get; set; }
        public string Kraj { get; set; }
        public string Nr_dokumentu { get; set; }
        public string Typ_dokumentu { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Nip { get; set; }
        public string Bank { get; set; }
        public string NumerKonta { get; set; }


        private void getUserData(string login)
        {
            Console.WriteLine("--->@getUserData()");
            string sqlsqlQuery = $"select * from F4_Uzytkownicy Where email = '{login}'";
            OracleConnection oracleConn = new OracleConnection(ConnString);
            Console.WriteLine("Open connection...");
            oracleConn.Open();
            Console.WriteLine("Connected status: " + oracleConn.State);
            OracleCommand cmd = new OracleCommand(sqlsqlQuery, oracleConn);
            OracleDataReader dataReader = cmd.ExecuteReader();
            if (!dataReader.HasRows)
            {
                Console.WriteLine("No data found");
                return;
            }
            try
            {
                while (dataReader.Read())
                {
                    UzytkownikId = (dataReader["uzytkownik_id"].ToString());
                    Imie = (dataReader["imie"].ToString());
                    Nazwisko = (dataReader["nazwisko"].ToString());
                    NazwaFirmy = (dataReader["nazwa_firmy"].ToString());
                    Nazwisko_rodowe = (dataReader["nazwisko_rodowe"].ToString());
                    Haslo = (dataReader["haslo"].ToString());
                    Ulica = (dataReader["ulica"].ToString());
                    KodPocztowy = (dataReader["kod_pocztowy"].ToString());
                    Miejscowosc = (dataReader["miejscowosc"].ToString());
                    Kraj = (dataReader["kraj"].ToString());
                    Nr_dokumentu = (dataReader["nr_dokumentu"].ToString());
                    Typ_dokumentu = (dataReader["typ_dokumentu"].ToString());
                    Email = (dataReader["email"].ToString());
                    Nip = (dataReader["nip"].ToString());
                    Telefon = (dataReader["telefon"].ToString());
                    Bank = (dataReader["bank"].ToString());
                    NumerKonta = (dataReader["numer_konta"].ToString());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                oracleConn.Close();
                Console.WriteLine("Connection status: " + oracleConn.State);
            }
        }
    }
}
