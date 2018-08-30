using System;
using System.Threading;

namespace _07Serilog
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();

            while (!Console.KeyAvailable) //addig fut, amíg nem ütöttünk le billentyűt
            {
                //véletlenszerűen kiválasztunk egy szintet/súlyt a bejegyzéshez
                var level = r.Next(100);

                //szimuláljuk egy tetszőleges alkalmazás működését
                //a kisebb súlyú bejegyzésekből többet szeretnénk, és minél súlyosabb egy bejegyzés, annál kevesebb legyen belőle

                if (level < 50)
                { //legkisebb súlyú, de legsűrűbben előforduló üzenet (Debug)

                }

                if (level >= 50 && level < 70)
                { //Info

                }

                if (level >= 70 && level < 85)
                { //Warning

                }

                if (level >= 85 && level < 95)
                { //Error

                }

                if (level >= 95)
                { //Fatal

                }
                Thread.Sleep(200);

            }
        }
    }
}
