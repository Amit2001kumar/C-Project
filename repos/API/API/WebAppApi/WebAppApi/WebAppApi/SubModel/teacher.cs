using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAppApi.Model;

namespace WebAppApi.SubModel
{
    public class teacher : Iteachaer
    {
        string connectionStrings = Startup.StaticConfiguration["demant:connectionString"];


        public List<departmentdetail> Get([FromForm] int departmentid)
        {
            List<departmentdetail> obj = new List<departmentdetail>();
            // DataTable dt = new DataTable();

            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = connectionStrings;
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from department where departmentid = @departmentid";
            cmd.Parameters.AddWithValue("@departmentid", departmentid);             //
            cmd.CommandType = CommandType.Text;
            NpgsqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    departmentdetail depart = new departmentdetail();
                    depart.departmentid = (int)reader["departmentid"];
                    depart.departmentname = (string)reader["departmentname"];

                    obj.Add(depart);
                }
            }

            cmd.Dispose(); ;
            conn.Close();

            return obj;

        }

        public Response Post([FromForm] departmentdetail dep)
        {
            Response obj = new Response();
            try
            {
                string query = @"
                        SELECT public.add_department_info(@pdepartmentname)
                 ";

                // string query = @"SELECT public.add_department_info(departmentname,null)";
                DataTable table = new DataTable();

                using (NpgsqlConnection myCon = new NpgsqlConnection(connectionStrings))
                {
                    myCon.Open();
                    using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                    {
                        //myCommand.Parameters.AddWithValue("@departmentid", dep.departmentid);
                        myCommand.Parameters.AddWithValue("@pdepartmentname", dep.departmentname);
                        myCommand.CommandType = System.Data.CommandType.Text;

                        int id = (int)myCommand.ExecuteScalar();
                        if (id > 0)
                        {
                            obj.status = true;
                            obj.message = "data successfully inserted";
                            obj.id = id;


                        }
                        else
                        {
                            obj.status = false;
                            obj.message = "Something went wrong";

                        }
                    }


                    myCon.Dispose();
                    myCon.Close();
                }

            }
            catch (Exception ex)
            {
                obj.status = true;

                obj.message = "exception ocured" + ex.Message;
            }


            return obj;
        }


        /*
                public Response Post([FromForm] departmentdetail dep)
                {
                    Response obj = new Response();
                    try
                    {
                         string query = @"
                                insert into department(departmentid,departmentname) values (@departmentid,@departmentname)
                         ";

                       // string query = @"SELECT public.add_department_info(departmentname,null)";
                        DataTable table = new DataTable();

                        using (NpgsqlConnection myCon = new NpgsqlConnection(connectionStrings))
                        {
                            myCon.Open();
                            using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                            {
                                myCommand.Parameters.AddWithValue("@departmentid", dep.departmentid);
                                myCommand.Parameters.AddWithValue("@departmentname", dep.departmentname);

                                var id = myCommand.ExecuteNonQuery();
                                if (id < 0)
                                {
                                    obj.status = true;
                                    obj.message = "data successfully inserted";
                                    obj.id = dep.departmentid;


                                }
                                else
                                {
                                    obj.status = false;
                                    obj.message = "Something went wrong";

                                }
                            }


                            myCon.Close();
                            myCon.Dispose();
                        }

                    }
                    catch (Exception ex)
                    {
                        obj.status = true;

                        obj.message = "exception ocured" + ex.Message;
                    }


                    return obj;
                }

                */



        public Response Put([FromForm] departmentdetail dep)
        {
            Response obj = new Response();

            string query = @"
                      update department set departmentname = @departmentname where departmentid = @departmentid
                ";

            DataTable table = new DataTable();

            try
            {

                // string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");

                using (NpgsqlConnection myCon = new NpgsqlConnection(connectionStrings))
                {
                    myCon.Open();
                    using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@departmentid", dep.departmentid);
                        myCommand.Parameters.AddWithValue("@departmentname", dep.departmentname);

                        var id = myCommand.ExecuteNonQuery();
                        if (id > 0)
                        {
                            obj.status = true;
                            obj.message = "data successfully UPDATED";
                            obj.id = dep.departmentid;


                        }
                        else
                        {
                            obj.status = false;
                            obj.message = "data NOT UPDATED";

                        }
                        myCon.Close();
                        myCon.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                obj.status = true;

                obj.message = "exception ocured" + ex.Message;

            }

            return obj;


        }



        public Response Delete([FromForm] int id)
        {
            Response obj = new Response();

            string query = @"
                      delete from department where departmentid = @id
                ";

            DataTable table = new DataTable();

            try
            {

                // string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
                // NpgsqlDataReader myReader;
                using (NpgsqlConnection myCon = new NpgsqlConnection(connectionStrings))
                {
                    myCon.Open();
                    using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@id", id);

                        //  myReader = myCommand.ExecuteReader();
                        // table.Load(myReader);


                        var ids = myCommand.ExecuteNonQuery();
                        if (id > 0)
                        {
                            obj.status = true;
                            obj.message = "data successfully deleted";


                        }
                        else
                        {
                            obj.status = false;
                            obj.message = "data NOT deleted";

                        }
                        myCon.Close();
                        myCon.Dispose();

                    }


                }


            }
            catch (Exception ex)
            {
                obj.status = true;

                obj.message = "exception ocured" + ex.Message;

            }

            return obj;

        }


    }
}










/* public Response Get()
{
   Response obj = new Response();
   string query = @"
   select departmentid as departmentid, departmentname as departmentname from department
";



   try
   {

       NpgsqlDataReader myReader;
       using (NpgsqlConnection myCon = new NpgsqlConnection(connectionStrings))
       {
           myCon.Open();
           using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
           {
               myReader = myCommand.ExecuteReader();
              // table.Load(myReader);

               myReader.Close();
               myCon.Close();

           }
       }
   }
   catch (Exception ex)
   {
       Console.WriteLine(ex.Message);

       Console.WriteLine("table not printed");
   }


   return obj;

}

*/

/*

public Response Post([FromForm] departmentdetail dep)
{
Response obj = new Response();

string query = @"
insert into department(departmentid,departmentname) values (@departmentid,@departmentname)
";

// DataTable table = new DataTable();

try
{

   // string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
    NpgsqlDataReader myReader;
    using (NpgsqlConnection myCon = new NpgsqlConnection(connectionStrings))
    {
        myCon.Open();
        using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
        {
            myCommand.Parameters.AddWithValue("@departmentid", dep.departmentid);
            myCommand.Parameters.AddWithValue("@departmentname", dep.departmentname);
            myReader = myCommand.ExecuteReader();
           // table.Load(myReader);

            myReader.Close();
            myCon.Close();




        }
    }
}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);

    Console.WriteLine("data not Added");

}

return obj;


}

*/



