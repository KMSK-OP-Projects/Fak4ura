using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fak4ura.Models
{
    public class CounterPartyData : DbConnection
    {
        public CounterPartyData() { }
     
        public CounterPartyData(string id)
        {
            getCounterPartyData(id);
        }


        public string Id { get; set; }
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
        public List<CounterPartyData> CounterPartyList { get; set; } = new List<CounterPartyData>();


        public void getCounterPartyDataList(string userId)
        {
            Console.WriteLine("--->@CounterPartyData()");
            string sqlsqlQuery = $"select * from F4_Kontrahenci WHERE uzytkownik_id = {userId}";
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
                    var obj = new CounterPartyData();
                    obj.Id = (dataReader["id"].ToString());
                    obj.Imie = (dataReader["imie"].ToString());
                    obj.Nazwisko = (dataReader["nazwisko"].ToString());
                    obj.NazwaFirmy = (dataReader["nazwa"].ToString());
                    obj.Ulica = (dataReader["ulica"].ToString());
                    obj.KodPocztowy = (dataReader["kod_pocztowy"].ToString());
                    obj.Miejscowosc = (dataReader["miejscowosc"].ToString());
                    obj.Telefon = (dataReader["telefon"].ToString());
                    obj.Email = (dataReader["email"].ToString());
                    obj.Nip = (dataReader["nip"].ToString());
                    obj.WWW = (dataReader["www"].ToString());
                    CounterPartyList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                oracleConn.Close();
                Console.WriteLine("Connection status: " + oracleConn.State);
            }
        }


        public void getCounterPartyData(string id)
        {
            Console.WriteLine("--->@CounterPartyData()");
            string sqlsqlQuery = $"select * from F4_Kontrahenci Where id = '{id}'";
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
                    Id = (dataReader["id"].ToString());
                    Imie = (dataReader["imie"].ToString());
                    Nazwisko = (dataReader["nazwisko"].ToString());
                    NazwaFirmy = (dataReader["nazwa"].ToString());
                    Ulica = (dataReader["ulica"].ToString());
                    KodPocztowy = (dataReader["kod_pocztowy"].ToString());
                    Miejscowosc = (dataReader["miejscowosc"].ToString());
                    Telefon = (dataReader["telefon"].ToString());
                    Email = (dataReader["email"].ToString());
                    Nip = (dataReader["nip"].ToString());
                    WWW = (dataReader["www"].ToString());
                }
            }
            catch (Exception ex)
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
