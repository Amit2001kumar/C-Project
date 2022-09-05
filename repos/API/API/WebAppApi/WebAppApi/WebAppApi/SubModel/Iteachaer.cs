using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppApi.Model;

namespace WebAppApi.SubModel
{
    public interface Iteachaer
    {
        List<departmentdetail> Get(int departmentid);
        Response Post(departmentdetail dep);
        Response Put(departmentdetail dep);
        Response Delete(int id);
    }
}
