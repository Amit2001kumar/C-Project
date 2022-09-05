using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array
{
   internal class Progmam
    {
        static void Main(string[] args)
        {
            string[] color = { "white", "red", "black", "blue", "green"  };  //0-3  (value 4)

            // int[] a = { 4, 3, 5, 2, 7, 8 };
            //  Console.WriteLine(a[5]);
            // color[2] = "gray";
            
            //color[2] = "gray";
            //Console.WriteLine(color[2]);  //value 0 se start 


            Console.WriteLine(color.ToList().IndexOf("white"));   //color 1 se start



            //  Console.WriteLine(color.ToList().IndexOf("pink"));    //-1


            


            Console.WriteLine(color.Length);  // array ki lenght

            /*var abc = color.ToList();    //convert array to list
            abc.Add("pink");            //add new value in list
            Console.WriteLine(abc.ToArray().Length);*/

            var abc = color.ToList();

            var index = abc.IndexOf("black");

            abc.RemoveAt(index);
            

            //update array value in string
            // color[3] = "yellow";
            // Console.WriteLine(color[2]);     //finding index name





            Console.ReadKey();

        }
    }
}
