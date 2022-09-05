using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_database.helper
{
    public class element
    {
        public void exam()

        {
            // creating folder

            var folderPath = ConfigurationManager.AppSettings["folderPath"];

            var newFolder = folderPath + "//testing";

            if (!Directory.Exists(newFolder))
            {
                Directory.CreateDirectory(newFolder);
            }

            else
            {
                Console.WriteLine("folder already exist");
            }

            // creating file

            var newFile = folderPath + "//testing//result.txt";


            if (!File.Exists(newFile))
            {
                File.Create(newFile);
            }

            else
            {
                Console.WriteLine("file already exist");
            }



            // write in the text file
            StreamWriter w = File.AppendText(newFile);

            w.WriteLine("Hello");

            w.WriteLine("\nHow are you");

            w.Flush();

            w.Close();

            Console.WriteLine("you have successfully written in text");






            //Reading a existing file program

            var read = ConfigurationManager.AppSettings["readfile"];
            var readfile = read + "//apple.txt";

            if (File.Exists(readfile))
            {
                Console.WriteLine("File found to read");
                string a = File.ReadAllText(readfile);
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine("File not found to read");
            }





            //execute date 

/*
            var date = System.DateTime.Now.Date.ToString("mm/dd/yyyy");
            var newFiles = folderPath + "//testing//error" + date + ".txt";

            if (File.Exists(newFiles +date))
            {
                File.Create(newFiles);
            }

            */
            

            
                        //Delete file 

                        var delete = ConfigurationManager.AppSettings["folderPath"];
                        var def = delete + "//testing//apple.txt";

                        if (File.Exists(def))
                        {
                            Console.WriteLine("file found");

                            File.Delete(def);
                            Console.WriteLine("file has been deleted successfully");
                        }
                        else
                        {
                            Console.WriteLine("file not found to delete");
                        }






                        //delete folder

                        var folterPath = delete + "//testing//New folder (1)";

                        if (Directory.Exists(folterPath))
                        {
                            Console.WriteLine("folder found");

                            Directory.Delete(folterPath, true);
                            Console.WriteLine("folder has been deleted successfully");
                        }
                        else
                        {
                            Console.WriteLine("file not has been deleted successfully");

                        }
                        

                        //count total files in folder 



           

        }
    }
}
