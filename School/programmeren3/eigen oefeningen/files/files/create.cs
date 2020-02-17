using System;
using System.IO;

namespace files
{
    class create
    {
        static void Main(string[] args)
        {
            string fileName = @"./test/Myfile.txt";
            try
            {
                using FileStream fileStream = File.Create(fileName);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
