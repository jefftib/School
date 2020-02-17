//using System;
//using System.IO;

//namespace files
//{
//    class createTekst
//    {
//        static void Main(string[] args)
//        {
//            string fileName = @"./test/Myfile.txt";
//            try
//            {
//                using (StreamWriter fileStream = File.CreateText(fileName))
//                {
//                    fileStream.WriteLine("hello and welcome");
//                }
//            }

//            catch(Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//            Console.ReadKey();

//            try
//            {
//                using (StreamReader sr = new StreamReader(fileName))
//                {
//                    string line = "";
//                    while ((line = sr.ReadLine()) != null)
//                    {
//                        Console.WriteLine(line);
//                    }
//                }
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//            Console.ReadKey();
//        }


//    }
//}
