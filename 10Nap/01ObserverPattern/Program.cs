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

            process.Subscribe(log);
            process.Subscribe(ui);

            process.Start();

            process.Unsubscribe(log);
            process.Unsubscribe(ui);

            Console.WriteLine("A folyamat lefutott");

            Console.ReadLine();
        }
    }
}
