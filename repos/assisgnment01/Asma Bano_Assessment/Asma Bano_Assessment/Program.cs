using Asma_Bano_Assessment.models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asma_Bano_Assessment
{
    public class Program
    {
        static string connectionString = ConfigurationManager.AppSettings["connectionString"];
        static void Main(string[] args)
        {
            Project_Details Pobj = new Project_Details();

            IProject_List obj = new Project_List();
            obj.L_insert(Pobj);


            Console.ReadKey();
        }
    }
}
