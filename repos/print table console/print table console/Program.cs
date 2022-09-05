using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace print_table_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ConnectionString = "Server=localhost; Port=5432; Database=Admin; User Id=postgres; password=2001; CommandTimeout=20";

            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = ConnectionString;

            string query = "select * from employees";

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;


            conn.Open();

            NpgsqlDataReader reader = cmd.ExecuteReader();

            if(reader.HasRows)
            {
                while(reader.Read () )
                {
                    Console.WriteLine("{0}    {1}    {2}    {3}      {4}",
                    reader["Empno"],    reader["Ename"],    reader["Job"],    reader["Salary"],    reader["Deptno"]);

                    //Console.WriteLine("{0},{1},{2},{3},{4}",reader["Empno"], reader["Ename"], reader["Job"], reader["Salary"], reader["Deptno"]);
                    
                }
                Console.ReadKey();
            }
        }
    }
}
