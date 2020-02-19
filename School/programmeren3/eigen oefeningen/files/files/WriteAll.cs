using System;
using System.IO;


namespace files
{
    class Writeall
    {
        static void Main(string[] args)
        {
            string fileName = @"./test/Myfile.txt";
            try
            {
                Console.Write("Specify number of lines to write");
                int n = Convert.ToInt32(Console.ReadLine());
                string[] arrayLines = new string[n];
                Console.Write("specify the {0} strings");
                for (var i = 0; i < n; i++)
                {
                    Console.Write("line {0}: ", i + 1);
                    arrayLines[i] = Console.ReadLine();
                }
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }


    }
}
