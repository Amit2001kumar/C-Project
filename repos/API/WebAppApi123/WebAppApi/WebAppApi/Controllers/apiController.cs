using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppApi.Model;
using WebAppApi.SubModel;

namespace WebAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class apiController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        public apiController(IWebHostEnvironment WebHostEnvironment)
        {
            _webHostEnvironment = WebHostEnvironment;
        }

        // teacher tech = new teacher();
        teacher tech = new teacher();


        [HttpGet, Route("select")]
        public List<departmentdetail> Get([FromForm] int departmentid)
        {
            List<departmentdetail> res = tech.Get(departmentid);

            return res;
        }


        
       [HttpPost, Route("insert")]
       public Response Post([FromForm] departmentdetail dep)                      //departmentdetail pub
       {

           Response res = tech.Post(dep);
           return res;
       }

        
       /*
              [HttpPut, Route("update")]
              public Response Put([FromForm] departmentdetail dep)
              {

                  Response res = tech.Put(dep);
                  return res;
              }

              [HttpDelete, Route("delete")]
              public Response Delete([FromForm]int id)
              {

                  Response res = tech.Delete(id);
                  return res;
              }
             
        */
    }
}




/*
[HttpGet, Route("select")]
public Response Get()
{

 Response res = tech.Get();
 return res;
}
*/


