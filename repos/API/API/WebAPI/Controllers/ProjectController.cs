using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        [HttpGet,Route("getprojectdetails")]
        public string GetProjectDetails() 
        {
            return "hello";
        }


        /*    [HttpPost, Route("addprojectdetails")]

             public bool AddProjectDetails([FromForm] Class obj)
             {
                 if (obj.project_name != "" && obj.project_name !=null)
                 {
                     return true;
                 }
                 else
                 {
                     return false;
                 }
            */

        [HttpGet, Route("addprojectdetails")]
        public Project AddProjectDetails([FromForm] Class obj)
        {
            Project sch = new Project();
            if (obj.project_name != "" && obj.project_name != null)
            {
                sch.status = true;
                sch.message = "data recieved successfully";
            }
            else
            {
                sch.status = false;
                sch.message = "data not recieved";
            }
            return sch;

        }

    }
}

