using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppApi.Email;
using WebAppApi.Model;

namespace WebAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        Iemailsd es = new emailsd();

        [HttpPost, Route("send")]
        public Response mail(emaildetail emd)
        {
            Response ES = es.mail(emd);

            return ES;
        }

    }
}
