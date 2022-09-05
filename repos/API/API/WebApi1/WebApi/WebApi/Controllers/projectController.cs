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
        /*
        [HttpGet,Route("getprojectdetails")]
        public string GetProjectDetails()
        {
            return "hello";
        }
        */



        [HttpGet, Route("getprojectdetails")]
        public List<project> GetProjectDetails()
        {
            List<project> obj = new List<project>()

                  {
                new project()
                {
                    project_name = "Computer",
                    project_desc = "Testing"
                },

                new project()
                {
                    project_name = "Software",
                    project_desc = "Testing"
                },

                 new project()
                {
                    project_name = "Apps",
                    project_desc = "Testing"
                },
                 new project()
                {
                    project_name = "Apps Software",
                    project_desc = "Testing"
                }
            };
            return obj;
        }
           



        
       /*  [HttpGet, Route("addprojectdetails")]
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


         */


       /* [HttpGet, Route("addprojectdetails")]
        public Response AddProjectDetails([FromForm] project obj)
        {
            Response res = new Response();
            if (obj.project_name != "" && obj.project_name != null)
            {
                res.status = true;
                res.message = "data recieved successfully"; 
            }
            else
            {
                res.status = false;
                res.message = "data not recieved";
            }
            return res;
        }
       */
    }
}
