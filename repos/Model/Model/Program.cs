using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Program
    {
        static void Main(string[] args)
        {
            Personaldetail obj = new Personaldetail();

            Console.WriteLine("enter your first name");
            string a = Console.ReadLine();

            Console.WriteLine("enter your last name");
            string b = Console.ReadLine();

            Console.WriteLine("enter your age");
            int c = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter your profession");
            string d = Console.ReadLine();

            Console.WriteLine("enter your country");
            string e = Console.ReadLine();

            Console.WriteLine("enter your phone no.");
            long f = Convert.ToInt64(Console.ReadLine());

            obj.firstName = a;                      //saving data
            obj.lastName = b;
            obj.age = c;
            obj.profession = d;
            obj.country = e;
            obj.phone = f;

            Savedetail(obj);        //funtion call
            Console.ReadLine();

        }


        static void Savedetail(Personaldetail obj)
        {
            Console.WriteLine("Enter your first name:" + obj.firstName);
            Console.WriteLine("Enter your last name:" + obj.lastName);
            Console.WriteLine("Enter your age:" + obj.age);
            Console.WriteLine("Enter your profession:" + obj.profession);
            Console.WriteLine("Enter your country:" + obj.country);
            Console.WriteLine("Enter your phone no.:" + obj.phone);
        }
    }
}

       /* public static void savedetails(Personaldetail obj)
        {
            var connectoinstring = "Server=127.0.0.1; Port=5432; Database=Training; User Id=postgres; password=2001; CommendTimeout=20";

            NpgsqlConnecion conn = new NpgsqlConnecion();
            conn.ConnectionString = connectoinstring;
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd commandText = "Insert into Employetable values(@Name,@Age,@Address)";
            cmd.Parameters.Add(new NpgsqlParameter("@Name", obj.Name));
            cmd Parameters.Add(new NpgsqlParameter("@Age", obj.age));
            cmd Parameters.Add(new NpgsqlParameter("@Address", obj.address));

        }

        private static void Add(NpgsqlParameter npgsqlParameter)
        {
            throw new NotImplementedException();
        }

        public static void getdetails(int empid)



        }

    internal class NpgsqlConnecion
    {
        public string ConnectionString { get; internal set; }

        internal void Open()
        {
            throw new NotImplementedException();
        }
    }
}
}
       */























           /* Console.WriteLine("enter your first name");
            obj.firstName = Convert.ToString(Console.ReadLine());

            Console.WriteLine("enter your last name");
            obj.lastName = Convert.ToString(Console.ReadLine());

            Console.WriteLine("enter your age");
            obj.age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter your profession");
            obj.profession = Convert.ToString(Console.ReadLine());

            Console.WriteLine("enter your country");
            obj.country = Convert.ToString(Console.ReadLine());

            Console.ReadLine();/*

            /*
                         SumModel obj = new SumModel();
                         obj.firstValue = 16;
                         obj.secondValue = 10;
                         obj.thirdValue = 32;
                         abc(obj);

                        Console.ReadKey();


                    public static void abc(SumModel obj)
                    {
                    var x = obj.firstValue + obj.secondValue + obj.thirdValue;
                    Console.WriteLine(x);
                    }
            */


            /* pobj.firstName = "Rahul";
               pobj.lastName = "Namdev";
               pobj.age = 20;
               pobj.profession = "Web devlopment";
               pobj.country = "India";
                savedetail(obj);

                public static savedetail(Personaldetail obj)
                {
                 Console.WriteLine(obj.firstValue);
                }

              */

        
   

