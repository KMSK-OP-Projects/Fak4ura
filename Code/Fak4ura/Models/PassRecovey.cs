using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Fak4ura.Models
{
    public class PassRecovery : DbConnection
    {
        public PassRecovery() { }
        public PassRecovery(string email)
        {
            Email = email;
            getUserPassword(email);
        }
        public string UzytkownikId { get; set; }
        public string Email { get;set;}
        public string Password { get; set; }
    

        private void getUserPassword(string email)
        {
            Console.WriteLine("--->@PassRecovery()");
            string sqlsqlQuery = $"select * from F4_Uzytkownicy Where email = '{email}'";
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
                    Password = (dataReader["haslo"].ToString());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("--->@PassRecovery()"+ ex.Message);
            }
            finally
            {
                oracleConn.Close();
                Console.WriteLine("Connection status: " + oracleConn.State);
            }
        }




        public string sendIt(string content)
        {
            // [important] https://accounts.google.com/b/0/DisplayUnlockCaptcha

            var sender = "fak4ura@gmail.com";
            const string senderPassword = "Toffifee";
            //var file = new Attachment(@"C:myreport.txt");
            MailMessage mailMsg = new MailMessage();
            MailAddress mailAdress = new MailAddress(sender);
            mailMsg.To.Add(Email);
            mailMsg.From = mailAdress;
            //mailMsg.Attachments.Add(file);
            mailMsg.Body = content;
            mailMsg.Subject = "Password reminder";

            var smtp = new SmtpClient();
            {
                smtp.Host = " smtp.gmail.com ";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(sender, senderPassword);
                smtp.Timeout = 20000;
            }
            try
            {
                smtp.Send(mailMsg);
            }
            catch (Exception ex)
            {
                return "⛌ " + ex.Message;
            }
            finally
            {
                //file.Dispose();
            }
            return "✓ Pomyślnie wysłano";
        }
    }
}
