using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppApi.Email
{
    public class emailsave
    {
        public string MailTo { get; set; }
        public string cc { get; set; }
        public string Bcc { get; set; }     
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
