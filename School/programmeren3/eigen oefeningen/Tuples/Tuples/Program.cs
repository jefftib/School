using System;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Tuple.Create(1, 2, 3, 4, 5, 6, 7, Tuple.Create(8, 9, 10, 11, 12, 13));
            var a =  numbers.Item1;
           var b = numbers.Item7;
           var c =  numbers.Rest.Item1;
            var d = numbers.Rest.Item1.Item1;

        }
    }
}
