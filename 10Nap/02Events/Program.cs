using System;

namespace _01ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //a két alkalmazás modul, ami igényt tart az információra
            //ők a megfigyelők: (Observers)

            //naplózás
            var log = new Logger();
            //és felhasználói felület
            var ui = new UserInterface();

            //a hosszantartó folyamatunk
            var process = new LongRunningProcess();

            process.DataChanged += log.Message;
            process.DataChanged += ui.Message;

            ///Problémák: 
            ///1. a híváslistát tudom kívülről inicializálni

            //process.ObserversCallList = null;

            ///2. a híváslistát meg tudom hívni kívülről
            //process.ObserversCallList(new LongRunningProcess());

            process.Start();

            process.DataChanged -= log.Message;
            process.DataChanged -= ui.Message;

            Console.WriteLine("A folyamat lefutott");

            Console.ReadLine();
        }
    }
}
