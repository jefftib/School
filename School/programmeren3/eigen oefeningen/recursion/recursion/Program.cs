using System;

namespace recursion
{
    class Program
    {
        static int PrintSom(int min, int val)
        {
            //stop creterium
            if (val == min)
            {
                return val;
            }
            return val + PrintSom(min, val - 1);
        }
        static void Main(string[] args)
        {
            Console.Write("Number to print");
            int val = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("the sum of the first natural nummer is", val, PrintSom(1,val));
            Console.ReadKey();
        }
       
    }
}
