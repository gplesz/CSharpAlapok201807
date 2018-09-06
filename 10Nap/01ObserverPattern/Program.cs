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
            var process = new LongRunningProcess(log, ui);
            //így is meghívhatnánk a params kulcsszó használatának hála:
            //process = new LongRunningProcess();
            //process = new LongRunningProcess(log);
            //process = new LongRunningProcess(log, ui, log, log);

            process.Start();

            Console.WriteLine("A folyamat lefutott");

            Console.ReadLine();
        }
    }
}
