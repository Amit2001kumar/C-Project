using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        string MailBody = "<!DOCTYPE html>" +
            "<html>" +
            "<body style =\"background -color:#ff7f26;text-align:center;\"> +
            "<h1 style=\


     

        public IActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Index(string toEmail)
        {
            return View();
        }
        

    }
}
