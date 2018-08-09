using System;
using System.Collections.Generic;
using System.Threading;

namespace _02GarbageCollectorExample1
{
    class Program
    {
        static void Main(string[] args)
        {
            var o = new MyObject();
            Console.WriteLine($"Korosítás: {GC.GetGeneration(o)}");
            GC.Collect();
            Console.WriteLine($"Korosítás: {GC.GetGeneration(o)}");
            GC.Collect();
            Console.WriteLine($"Korosítás: {GC.GetGeneration(o)}");
            GC.Collect();
            Console.WriteLine($"Korosítás: {GC.GetGeneration(o)}");
            GC.Collect();
            Console.WriteLine($"Korosítás: {GC.GetGeneration(o)}");
            GC.Collect();
            Console.WriteLine($"Korosítás: {GC.GetGeneration(o)}");
            GC.Collect();
            Console.WriteLine();

            var tartalom = new List<string>();

            for (int i = 0; i < 600; i++)
            {
                Thread.Sleep(20);
                tartalom.Add(new string('C', 6000));
                Console.Write(GC.GetGeneration(tartalom));
            }

            Console.ReadLine();
        }
    }
}
