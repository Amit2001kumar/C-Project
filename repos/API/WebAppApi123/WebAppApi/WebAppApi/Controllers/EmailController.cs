using Microsoft.AspNetCore.Mvc;
using WebAppApi.Email;
using WebAppApi.email1;
using WebAppApi.Model;

namespace WebAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        Iemailsd es = new emailsd();

        [HttpPost, Route("send")]
        public Response mail(depart emd)
        {
            Response ES = es.mail(emd);

            return ES;
        }

        







        
       /* Iemailsend _emailService = null;
        public EmailController context;
        public EmailController(Iemailsend emailService)
        {
            _emailService = emailService;
        }


        
        [HttpPost, Route("email")]
        public string SendEmail(emailsend emailData)
        {
            return _emailService.SendEmail(emailData);

        }*/
        
    }
}
