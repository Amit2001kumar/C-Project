using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_database.helper
{
    public class listprint
    {
        public void member()
        {

            //  string connectionString = ConfigurationManager.AppSettings["connectionString"];  //this connection string is used from app config
            var ConnectionString = "Server=localhost; Port=5432; Database=postgres; User Id=postgres; password=2001; CommandTimeout=20";


            List<savedetails> emplist = new List<savedetails>();

            savedetails emp1 = new savedetails()
            {
                id = 21,
                name = "rahul",
                email = "rahul43@gmail.com",
                location = "jabalpur"
            };

            savedetails emp2 = new savedetails()
            {
                id = 22,
                name = "raj",
                email = "raj87@gmail.com",
                location = "katni"
            };


            savedetails emp3 = new savedetails()
            {
                id = 23,
                name = "raja",
                email = "raja652@gmail.com",
                location = "indore"
            };


            savedetails emp4 = new savedetails()
            {
                id = 24,
                name = "mohit",
                email = "mohit9874@gmail.com",
                location = "bhopal"
            };



            emplist.Add(emp1);
            emplist.Add(emp2);
            emplist.Add(emp3);
            emplist.Add(emp4);




            foreach (savedetails emp in emplist)
            {
                //Console.WriteLine("employee id is: {0} name is: {1} age is: {2} designation is: {3}", emp.id, emp.name, emp.email, emp.location);

                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = ConnectionString;
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Insert into student values(@id,@name,@email,@location)";
                cmd.Parameters.Add(new NpgsqlParameter("@id", emp.id));
                cmd.Parameters.Add(new NpgsqlParameter("@name", emp.name));
                cmd.Parameters.Add(new NpgsqlParameter("@email", emp.email));
                cmd.Parameters.Add(new NpgsqlParameter("@location", emp.location));
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                conn.Close();

                Console.WriteLine("successfully print ");




                //Console.WriteLine("successfully print ");


                /*
                                //integer list

                                List<int> mynumber = new List<int>();
                                mynumber.Add(1);
                                mynumber.Add(2);
                                mynumber.Add(3);
                                mynumber.Add(4);
                                mynumber.Add(5);
                                mynumber.Add(6);

                                foreach (int i in mynumber)
                                {
                                    Console.WriteLine(i);
                                }


                                //string list

                                List<string> name = new List<string>();
                                name.Add("amit");
                                name.Add("sumit");
                                name.Add("ankit");
                                name.Add("anil");
                                name.Add("ankit");


                                foreach (string i in name)
                                {
                                    Console.WriteLine(i);
                                }

                */





            }

        }

    }
}

        
    



