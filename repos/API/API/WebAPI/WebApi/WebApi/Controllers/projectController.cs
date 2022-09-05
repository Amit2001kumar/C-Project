using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class projectController : ControllerBase
    {
        [HttpGet,Route("getprojectdetails")]
        public string GetProjectDetails()
        {
            return "hello";
        }

        [HttpGet, Route("addprojectdetails")]
        public bool AddProjectDetails([FromForm] project obj)
        {
            if (obj.project_name != "" && obj.project_name != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
