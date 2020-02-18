using System;

namespace MyRecursion
{
    class Program
    {
      static int Som(int min, int val)
        {
            if (val == min) 
            {
                return val;
            }
            return val + Som(1, val - 1);
        }



        static int getallenTellen(int n, int NrDigits) 
        {
            if( n == 0) 
            {
                return NrDigits;
            }
            return getallenTellen(n / 10, ++NrDigits);
        }

        static void Main(string[] args)
        {

            /*          tel alle voorgaande getallene bij elkaar op
             *          
             *          Console.WriteLine("geef een getal in");
                        int val = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("De som is " + Som(1, val));
                        Console.ReadKey();
             */

            // onderstaande telt het aantal cijfers in een getal.
            Console.WriteLine("Geef het te tellen getal in");
            int val = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Het te tellen getal bestaat uit " + getallenTellen(val,0) + " Cijfers.");
            Console.ReadKey();
         
        
        }
    }
}
