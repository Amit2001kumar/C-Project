using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebAppApi.Model;

namespace WebAppApi.Email
{
    public class emailsd : Iemailsd
    {
        public Response mail(depart emd)
        {
           
            Response obj = new Response();
            try
            {

                MailMessage msg = new MailMessage();
                SmtpClient smtp = new SmtpClient();


                msg.From = new MailAddress("amit.rai@cylsys.com");              
                msg.To.Add(emd.MailTo);
                msg.Subject = emd.Subject;
                msg.CC.Add(emd.cc);
                //msg.Bcc.Add("amitkumarrai172001@gmail.com");
                msg.Body = "hello i am amit kumar ";
                msg.IsBodyHtml = true;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("amit.rai@cylsys.com", "Password@2");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(msg);
                obj.message = "Mail send successfully";
              

            }
            catch (Exception ex)
            {
                obj.status = true;

                obj.message = "exception error" + ex.Message;
            }
            return obj;
        }
    }
}
