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

        static int CountDigits(int n, int nrdigitis)
        {
            //stop creterium
            if (n == 0)
            {
                return nrdigitis;
            }
            return CountDigits(n/10, ++nrdigitis);
        }

        static void Main(string[] args)
        {
            Console.Write("Number to print");
            int val = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(CountDigits(val, 0));
            Console.ReadKey();
        }
       
    }
}
