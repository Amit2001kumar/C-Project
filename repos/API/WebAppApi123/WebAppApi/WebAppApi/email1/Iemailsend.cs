using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppApi.email1
{
    public interface Iemailsend
    {
        string SendEmail(Emaildata emailData);
        string SendEmail(emailsend emailData);
    }
}
