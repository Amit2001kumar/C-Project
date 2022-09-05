using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum,subs,m,d;
            
            sum = add(4, 2);
            Console.WriteLine(sum);
            subs = sub(4, 2);
            Console.WriteLine(subs);
            m = mul(4, 2);
            Console.WriteLine(m);
            d = div(4, 2);
            Console.WriteLine(d);

            Console.ReadLine();
        }
        static int add(int a, int b)
        {
            return a + b;
        }
        static int sub(int a, int b)
        {
            return a - b;
        }
        static int mul(int a, int b)
        {
            return a * b;
        }
        static int div(int a, int b)
        {
            return a / b;
        }

    }
}
