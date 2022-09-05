using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebAppApi.Model;

namespace WebAppApi.Email
{
    public class emailsd : Iemailsd
    {
        string connectionStrings = Startup.StaticConfiguration["demant:connectionString"];

        //string FilePath = Startup.StaticConfiguration["demant:FilePath"];
        public Response mail(emaildetail emd)
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
                //msg.Bcc.Add(emd.Bcc);

                /*
             // string FilePath = "C:\\Users\\Amit Rai\\source\\repos\\API\\API\\WebAppApi\\WebAppApi\\WebAppApi\\htmlpage.html";
                StreamReader str = new StreamReader(FilePath);
                string MailText = str.ReadToEnd();
                str.Close();
                msg.Body = MailText;
                */
                msg.Body =
                    "<html>" +
                    "<head>" +
                    "<style>div{background-color:blue;color:white;}" +
                    "div { border: 10px solid red;}</style>" +
                    "</head>" +
                    "<body>" +
                    "<div>" +
                    "<h1>Wonder of Science</h1>" +
                    "<p>Science is playing important role in over life." +
                    "<br>" +
                    " There are many wonder of Science and the great invention of science." +
                    "<br>" +
                    " It is age of science.science is made over life comfortable and easier." +
                    "<br>" +
                    "It has nothing but systematic way of living and the knowledge." +
                    "<br>" +
                    " Alertness and curiosity  and observation changes in over life happenings has give to science." +
                    "<br>" +
                    "</p></div>" +
                    "</html>";
               
              
               
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