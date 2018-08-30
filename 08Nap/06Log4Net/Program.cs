using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06Log4Net
{
    class Program
    {
        //ezen a proerty-n keresztül az adott osztály összes naplóje ezen keresztül megy
        //http://logging.apache.org/log4net/release/faq.html#static-class-name
        //érdemes a névben utalni arra az osztályra, aminek a naplójáról van szó.
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger("_06Log4Net.Program");
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            //betöltjük az app.config-ból a log4net konfigurációt
            log4net.Config.XmlConfigurator.Configure();

            var r = new Random();

            while (!Console.KeyAvailable) //addig fut, amíg nem ütöttünk le billentyűt
            {
                //véletlenszerűen kiválasztunk egy szintet/súlyt a bejegyzéshez
                var level = r.Next(100);

                //szimuláljuk egy tetszőleges alkalmazás működését
                //a kisebb súlyú bejegyzésekből többet szeretnénk, és minél súlyosabb egy bejegyzés, annál kevesebb legyen belőle

                if (level<50)
                { //legkisebb súlyú, de legsűrűbben előforduló üzenet (Debug)
                    log.Debug($"Debug üzenet: {level}");
                }

                if (level>=50 && level<70)
                { //Info
                    log.Info($"Info üzenet: {level}");
                }

                if (level>=70 && level<85)
                { //Warning
                    log.Warn($"Warn üzenet: {level}");
                }

                if (level>=85 && level<95)
                { //Error
                    log.Error($"Error üzenet: {level}");
                }

                if (level>=95)
                { //Fatal
                    log.Fatal($"Fatal üzenet: {level}");
                }
                Thread.Sleep(200);

            }
        }
    }
}
