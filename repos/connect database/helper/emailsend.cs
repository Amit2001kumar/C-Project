using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace connect_database.helper
{
    public class emailsend
    {
        public void mail()
        {

            MailMessage msg = new MailMessage();
            SmtpClient smtp = new SmtpClient();


            msg.From = new MailAddress("amit.rai@cylsys.com");
            msg.To.Add("raia6934@gmail.com");
            msg.Subject = "Test Mail";
            msg.Body = "Hello, < This is amit";

            smtp.Host = "smtp-mail.outlook.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("amit.rai@cylsys.com", "Password@2");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.Send(msg);
        }
    }
}
