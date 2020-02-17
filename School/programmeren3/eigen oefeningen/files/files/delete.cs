using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace files
{
    class delete
    {

        static void Main(string[] args)
        {
            string fileName = @"./test/Myfile.txt";

      
                if (File.Exists(fileName))
                    File.Delete(fileName);
            Console.WriteLine($"file:{fileName} is deleted succesfully");
                }
           
        }

        }
