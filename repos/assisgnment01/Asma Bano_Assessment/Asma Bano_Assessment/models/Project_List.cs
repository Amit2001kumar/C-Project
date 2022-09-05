using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asma_Bano_Assessment.models
{
    public class Project_List:IProject_List
    {


        static string connectionString = ConfigurationManager.AppSettings["connectionString"];   //this connection string 

       

        //this is usd to add employee data to table


        
        public void L_insert(Project_Details Pobj)
        {

            /*.....................INSERTION THROUGH LIST ......................*/

            List<Project_Details> abc = new List<Project_Details>();

            Project_Details emp1 = new Project_Details()
            {

                project_id=111,
                project_name="Android task monitoring system",
                project_start_date ="2021/01/07",
                project_end_date="2022/02/08"

            };

            abc.Add(emp1);

            Project_Details emp2 = new Project_Details()
            {
                project_id = 112,
                project_name = "Fingerprint-based ATM system",
                project_start_date = "2018/04/11",
                project_end_date = "2019/04/11"

            };

            abc.Add(emp2);
            Project_Details emp3 = new Project_Details()
            {
                project_id = 113,
                project_name = "Mobile Development",
                project_start_date = "2016/03/10",
                project_end_date = "2017/03/10"

            };

            abc.Add(emp3);

            Project_Details emp4 = new Project_Details()
            {
                project_id = 114,
                project_name = "Weather forecasting system",
                project_start_date = "2019/06/3",
                project_end_date = "2020/06/4"

            };

            abc.Add(emp4);

            Project_Details emp5 = new Project_Details()
            {
                project_id = 115,
                project_name = "Fingerprint voting system",
                project_start_date = "2002/01/12",
                project_end_date = "2004/01/11"

            };

            abc.Add(emp5);
            Project_Details emp6 = new Project_Details()
            {
                project_id = 116,
                project_name = "Credit card fraud detection",
                project_start_date = "2003/04/11",
                project_end_date = "2004/04/11"

            };

            abc.Add(emp6);

            Project_Details emp7 = new Project_Details()
            {
                project_id = 117,
                project_name = "Full-Stack Development",
                project_start_date = "2005/05/12",
                project_end_date = "2006/05/12"

            };

            abc.Add(emp7);

            Project_Details emp8 = new Project_Details()
            {
                project_id = 118,
                project_name = "Database Development",
                project_start_date = "2007/05/12",
                project_end_date = "2008/06/10"

            };

            abc.Add(emp8);

            Project_Details emp9 = new Project_Details()
            {
                project_id = 119,
                project_name = "Cloud Computing",
                project_start_date = "2019-05-09",
                project_end_date = "2020/05/12"

            };

            abc.Add(emp9);

            Project_Details emp10 = new Project_Details()
            {
                project_id = 120,
                project_name = "Web Development",
                project_start_date = "2011/05/9",
                project_end_date = "2012/07/12"

            };

            abc.Add(emp10);

            foreach (Project_Details emp in abc)
            {
                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();

                    conn.ConnectionString = connectionString;
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Insert Into project Values(@p_id,@p_name,@p_start_date,@p_end_date)";
                    cmd.Parameters.Add(new NpgsqlParameter("@p_id", emp.project_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@p_name", emp.project_name));
                    cmd.Parameters.Add(new NpgsqlParameter("@p_start_date", emp.project_start_date));
                    cmd.Parameters.Add(new NpgsqlParameter("@p_end_date", emp.project_end_date));
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                    Console.WriteLine("data has been inserted successfully");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                        
                    Console.WriteLine("please try after sometime");
                }
            }





           

        }






    }
}
