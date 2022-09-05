using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_database.helper
{
    public class studentdetail : Istudentdetail     // call in interface class
    {
        static string connectionString = ConfigurationManager.AppSettings["connectionString"];  //this connection string is used from app config
       public void study(savedetails obj)   //inserting detail into student date top table
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

        public void getdetails(int id)      // Information getting from table
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
            catch (Exception ex)
            {
                //ex.Message
                //Console.WriteLine(ex.Message);

                Console.WriteLine("Please try after some time");

            }
        }
    }
}
