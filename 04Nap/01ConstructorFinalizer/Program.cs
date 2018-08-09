using System;

namespace _01ConstructorFinalizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = new Base();
            Console.WriteLine();

            var m = new Middle();
            Console.WriteLine();

            var t = new Third();
            Console.WriteLine();

            //paraméterrel rendelkező konstruktorok használata
            b = new Base("ez az alaposztály");
            Console.WriteLine();

            b = new Base("ez az alaposztály", "alap@alap.hu");
            Console.WriteLine();

            Console.ReadLine();

        }
    }
}
