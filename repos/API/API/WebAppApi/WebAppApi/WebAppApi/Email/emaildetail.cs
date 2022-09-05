using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppApi.Email
{
    public class emaildetail
    {
        public string MailTo { get; set; }
        public string cc { get; set; }
        public string Bcc { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Host { get; set; }
        public string SmtpHost { get; set; }
        public int Port { get; set; }
        public string MailFrom { get; set; }
       
    }
}
