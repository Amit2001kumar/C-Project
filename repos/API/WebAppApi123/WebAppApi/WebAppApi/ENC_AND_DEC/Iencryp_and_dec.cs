using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppApi.Model;

namespace WebAppApi.ENC_AND_DEC
{
    public interface Iencryp_and_dec
    {
        Response Encrypt(depart enc);
        Response Decrypt(depart dec);
    }
}
