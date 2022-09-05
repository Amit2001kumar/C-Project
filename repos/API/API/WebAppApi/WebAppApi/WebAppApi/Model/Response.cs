using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppApi.Model
{
    public class Response
    {
        public int id { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
}
