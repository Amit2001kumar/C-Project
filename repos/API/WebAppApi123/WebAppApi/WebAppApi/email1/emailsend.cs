using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppApi.Email;

namespace WebAppApi.email1
{
    public class emailsend : Iemailsend
    {
        string connectionStrings = Startup.StaticConfiguration["demant:connectionString"];

        Emaildetail _emaildetail = null;

        public emailsend(IOptions<Emaildetail> options)
        {
            _emaildetail = options.Value;
        }
        public string SendEmail(Emaildata emailData)
        {
            try
            {
                MimeMessage emailMessage = new MimeMessage();
                MailboxAddress emailFrom = new MailboxAddress(_emaildetail.Name, _emaildetail.EmailId);
                emailMessage.From.Add(emailFrom);
                MailboxAddress emailTo = new MailboxAddress(emailData.EmailToName, emailData.EmailToId);
                emailMessage.To.Add(emailTo);
                emailMessage.Subject = emailData.EmailSubject;
                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.TextBody = emailData.EmailBody;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();
                SmtpClient emailClient = new SmtpClient();
                emailClient.Connect(_emaildetail.Host, _emaildetail.Port, _emaildetail.UseSSL);
                emailClient.Authenticate(_emaildetail.EmailId, _emaildetail.Password);
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();
                return "Email Send Successfully....";
            }
            catch (Exception)
            {
                return "Email Not Sent...";
            }
        }

        public string SendEmail(emailsend emailData)
        {
            throw new NotImplementedException();
        }
    }
}
