using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_database
{
    internal class Program
    {
        private static string connectoinstring;

        public static string ConnectionString { get; private set; }

        static void Main(string[] args)
        {
            savedetails obj = new savedetails();
            obj.id = 01;
            obj.name = "Rohan";
            obj.email = "Rohan123@gmail.com";
            obj.location = "mumbai";
            study(obj);
           // getdetails(02);
            Console.ReadKey();
        }
        static void study(savedetails obj)
        {
            var ConnectionString = "Server=localhost; Port=5432; Database=Admin; User Id=postgres; password=2001; CommandTimeout=20";

            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = ConnectionString;
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
            var ConnectionString = "Server=localhost; Port=5432; Database=Admin; User Id=postgres; password=2001; CommandTimeout=20";

            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = ConnectionString;
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
    }

}