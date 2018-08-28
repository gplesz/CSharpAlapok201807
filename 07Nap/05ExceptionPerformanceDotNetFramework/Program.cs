using System;
using System.Diagnostics;

namespace _05ExceptionPerformanceDotNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception)
                { }
            }
            Console.WriteLine($"Eltelt idő: {sw.ElapsedTicks}");

            sw.Restart();
            for (int i = 0; i < 1000; i++)
            {
                //try
                //{
                //    throw new Exception();
                //}
                //catch (Exception)
                //{ }
            }
            sw.Stop();
            Console.WriteLine($"Eltelt idő: {sw.ElapsedTicks}");

            //Eltelt idő: 537038
            //Eltelt idő: 28

            Console.ReadLine();
        }
    }
}
