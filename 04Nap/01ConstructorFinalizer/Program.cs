using System;

namespace _01ConstructorFinalizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = new Base();
            Console.WriteLine();

            //var m = new Middle();
            //Console.WriteLine();

            //var t = new Third();
            //Console.WriteLine();

            //paraméterrel rendelkező konstruktorok használata
            b = new Base("ez az alaposztály");
            Console.WriteLine();

            b = new Base("ez az alaposztály", "alap@alap.hu");
            Console.WriteLine();

            var m = new Middle("ez a middle", "middle@middle.hu");
            Console.WriteLine($"név: {m.Name}, email: {m.Email}");
            Console.WriteLine();

            var t = new Third("ez a third", "third@third.hu");
            Console.WriteLine($"név: {t.Name}, email: {t.Email}");
            Console.WriteLine();

            b = null;
            m = null;
            t = null;

            //Ahhoz, hogy a szemétgyűjtő lefusson, ki kell kényszerítenünk egy takarítást.
            //ezt a kódot ne futtassuk a programunkban.

            GC.Collect();

            Console.ReadLine();

        }
    }
}
