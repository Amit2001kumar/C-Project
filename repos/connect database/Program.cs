using connect_database.helper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_database
{
    public class Program
    {
        
        //static string connectionString = ConfigurationManager.AppSettings["connectionString"];
        //static string email = ConfigurationManager.AppSettings["adminEmail"];


        //static string connectionString = "Server=localhost; Port=5432; Database=postgres; User Id=postgres; password=2001; CommandTimeout=20";


        static void Main(string[] args)
        {



            //emailsend call

           // emailsend es = new emailsend();
            //es.mail();

            //list print
           
            //listprint l = new listprint();
           // l.member();


            //element class folder,file,text generate
           // element e = new element();
               // e.exam();

           /* savedetails obj = new savedetails();
            obj.id = 10;
            obj.name = "Purnima";
            obj.email = "Purnima123@gmail.com";
            obj.location = "US";
           */

            Istudentdetail abc = new studentdetail();

           // abc.study(obj);
           // abc.getdetails(02);

                     //studentdetail.study(obj);
                     //studentdetail.getdetails(02);

            Console.ReadKey();



           
        }









       /* 
        
        static void study(savedetails obj)
        {
            //var connectionString = "Server=localhost; Port=5432; Database=postgres; User Id=postgres; password=2001; CommandTimeout=20";

            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Insert into student values(@id,@name,@email,@location)";
            cmd.Parameters.Add(new NpgsqlParameter("@id", obj.id));
            cmd.Parameters.Add(new NpgsqlParameter("@name", obj.name));
            cmd.Parameters.Add(new NpgsqlParameter("@email", obj.email));
            cmd.Parameters.Add(new NpgsqlParameter("@location", obj.location));
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();

            Console.WriteLine("successfully print ");


        }

        public static void getdetails(int id)
        {
            try
            {

                //var ConnectionString = "Server=localhost; Port=5432; Database=postgres; User Id=postgres; password=2001; CommandTimeout=20";

                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from student where id = @id";

                cmd.Parameters.Add(new NpgsqlParameter("@id", id));

                cmd.CommandType = System.Data.CommandType.Text;

                Npgsql.NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var n = reader["location"] as string;
                }

                //cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Please try after some time");
            }
        }
       */
    }

}

   
        
    

