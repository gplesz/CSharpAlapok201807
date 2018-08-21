using System;
using System.Drawing;
using System.IO;

namespace _03GarbageCollectorExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (!Console.KeyAvailable)
            {
                //ezzel nagyon megdolgoztatjuk a .NET Core memóriakezelését 
                //(A full dotnet nem is tudja ezt a kódot 10 másodpercnél tovább futtatni, a Core sokkal jobban teljesít)
                //var bitmap = new Bitmap(2048, 2048);

                //ha a takarításra is figyelek a finelizer segítségével 
                //akkor sem memória sem processzor problémába nem futunk.
                //using (var bitmap = new Bitmap(2048, 2048)) { }

                using (var stream = new MemoryStream(1000000000)) { }
            }
        }
    }
}
