using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppApi.Model;

namespace WebAppApi.Email
{
    public interface Iemailsd
    {
        public Response mail(emaildetail emd);

    }
}
