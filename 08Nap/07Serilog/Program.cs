using Serilog;
using System;
using System.Threading;

namespace _07Serilog
{
    class Program
    {
        static void Main(string[] args)
        {
            //A Serilog Logger statikus property-je mindenhonnan elérhető az alkalmazásunkból
            Serilog.Log.Logger = new Serilog.LoggerConfiguration()
                                            .WriteTo.Console()
                                            .CreateLogger();


            var r = new Random();

            while (!Console.KeyAvailable) //addig fut, amíg nem ütöttünk le billentyűt
            {
                //véletlenszerűen kiválasztunk egy szintet/súlyt a bejegyzéshez
                var level = r.Next(100);

                //szimuláljuk egy tetszőleges alkalmazás működését
                //a kisebb súlyú bejegyzésekből többet szeretnénk, és minél súlyosabb egy bejegyzés, annál kevesebb legyen belőle

                if (level < 50)
                { //legkisebb súlyú, de legsűrűbben előforduló üzenet (Debug)
                    //mivel a névtér már be van töltve, nem kell elé a Serilog névtér név
                    Log.Logger.Debug($"Debug: {level}");
                }

                if (level >= 50 && level < 70)
                { //Info
                    Log.Logger.Information($"Information: {level}");
                }

                if (level >= 70 && level < 85)
                { //Warning
                    Log.Logger.Warning($"Warning: {level}");
                }

                if (level >= 85 && level < 95)
                { //Error
                    Log.Logger.Error($"Error: {level}");
                }

                if (level >= 95)
                { //Fatal
                    Log.Logger.Fatal($"Fatal: {level}");
                }
                Thread.Sleep(200);

            }
        }
    }
}
