using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate
{
    internal class Program
    {
      
      
            static void Main()
             {
                int a, s, m, d, x, y;
                Console.WriteLine("Enter value of a:");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter value of b:");
                y = Convert.ToInt32(Console.ReadLine());
                // compute operation
                a = x + y;
                s = x - y;
                m = x * y;
                d = x / y;

                // display output
                Console.WriteLine("Addition: " + a);
                Console.WriteLine("Subtraction: " + s);
                Console.WriteLine("Multiplication: " + m);
                Console.WriteLine("Division: " + d);

                // wait for user to press any key
                Console.ReadKey();
            }
        }
    }
