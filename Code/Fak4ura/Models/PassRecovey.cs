using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Fak4ura.Models
{
    public class PassRecovery
    {
        // [important] https://accounts.google.com/b/0/DisplayUnlockCaptcha

        public string sendIt(string recipientAdress, string content)
        {
            var sender = "fak4ura@gmail.com";
            const string senderPassword = "Toffifee";
            //var file = new Attachment(@"C:myreport.txt");
            MailMessage mailMsg = new MailMessage();
            MailAddress mailAdress = new MailAddress(sender);
            mailMsg.To.Add(recipientAdress);
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
                return "Successfully sent  ✓";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                //file.Dispose();
            }
        }
    }
}
