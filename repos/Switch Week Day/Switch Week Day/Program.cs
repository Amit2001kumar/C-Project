using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switch_Week_Day
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int day;
            Console.WriteLine("user input value bitween 1 to 7:");
            day = Convert.ToInt32(Console.ReadLine());

            if (day <= 7) 

            {
                switch (day)
                {
                    case 1:
                        Console.WriteLine("Monday");
                        break;
                    case 2:
                        Console.WriteLine("Tuesday");
                        break;
                    case 3:
                        Console.WriteLine("Wednesday");
                        break;
                    case 4:
                        Console.WriteLine("Thursday");
                        break;
                    case 5:
                        Console.WriteLine("Friday");
                        break;
                    case 6:
                        Console.WriteLine("Saturday");
                        break;
                    case 7:
                        Console.WriteLine("Sunday");
                        break;
                }
            }

            else
            {
                Console.WriteLine("enter your number bitween 1 to 7");
            }

            Console.ReadKey();
        }
    }

}