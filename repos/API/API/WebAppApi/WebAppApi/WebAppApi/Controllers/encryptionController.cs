using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Npgsql;
using WebAppApi.Model;
using WebAppApi.SubModel;
using WebAppApi.ENC_AND_DEC;

namespace WebAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class encryptionController : ControllerBase
    {
        string connectionStrings = Startup.StaticConfiguration["demant:connectionString"];

        //encryp_and_dec ed = new encryp_and_dec();

        Iencryp_and_dec ed = new encryp_and_dec();


        [HttpPost, Route("encrypt")]
        public Response Encrypt(depart enc)
        {
            Response DJ = ed.Encrypt(enc);

            return DJ;
        }


        [HttpPost, Route("decrypt")]
        public Response Decrypt(depart dec)
        {
            Response DJ = ed.Decrypt(dec);

            return DJ;
        }
            

    }
}
