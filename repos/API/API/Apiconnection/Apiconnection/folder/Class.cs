using Apiconnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Apiconnection.folder
{
    public class Class
    {
        private readonly IConfiguration _configuration;
        public Class(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet, Route("select")]
        public JsonResult Get()
        {
          
            string query = @"
                select departmentid as ""departmentid"",departmentname as ""departmentname"" from department
        ";
           
                DataTable table = new DataTable();

            try
            {
                string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
                NpgsqlDataReader myReader;
                using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

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


     return new JsonResult(table);

 }
    
        

           

        
    


        [HttpPost, Route("insert")]
        public JsonResult Post(Department dep)
        {
           

            string query = @"
               insert into department(departmentid,departmentname) values (@departmentid,@departmentname)
        ";

            DataTable table = new DataTable();

            try
            {

                string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
                NpgsqlDataReader myReader;
                using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@departmentid", dep.DepartmentId);
                        myCommand.Parameters.AddWithValue("@departmentname", dep.DepartmentName);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

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

            return new JsonResult("Added Successfully");
        
           
        }






        [HttpPut, Route("update")]
        public JsonResult Put(Department dep)
        {
          
            string query = @"
              update department set departmentname = @departmentname where departmentid = @departmentid
        ";

            DataTable table = new DataTable();

            try
            {

                string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
                NpgsqlDataReader myReader;
                using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@departmentid", dep.DepartmentId);
                        myCommand.Parameters.AddWithValue("@departmentname", dep.DepartmentName);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                        myCon.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Console.WriteLine("data not update");

            }

            return new JsonResult("Updated Successfully");
        
           
        }







        [HttpDelete("{id}"), Route("delete")]
        public JsonResult Delete(int id)
        {
           
            string query = @"
              delete from department where departmentid = @departmentid
        ";

            DataTable table = new DataTable();

            try
            {

                string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
                NpgsqlDataReader myReader;
                using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@departmentid", id);

                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                        myCon.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Console.WriteLine("data not deleted");

            }

            return new JsonResult("Deleted Successfully");
        }
    }
}

