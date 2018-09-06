using System;
using System.Threading;

namespace _01ObserverPattern
{
    /// <summary>
    /// Egy hosszú folyamatot elvégző osztály példája
    /// Ő értesíti a többieket, ha valami történt
    /// Megfigyelhető/megfigyelt szereplő (Observeble)
    /// </summary>
    public class LongRunningProcess
    {
        private Logger log;
        private UserInterface ui;

        public LongRunningProcess(Logger log, UserInterface ui)
        {
            this.log = log;
            this.ui = ui;
        }

        public void Start()
        {
            Console.WriteLine("LongRunningProcess: 0%");

            //todo: értesíteni a kíváncsiskodókat (Observer)
            log.Message(0);
            ui.Message(0);

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 25%");
            log.Message(25);
            ui.Message(25);

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 50%");
            log.Message(50);
            ui.Message(50);

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 75%");
            log.Message(75);
            ui.Message(75);

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 100%");
            log.Message(100);
            ui.Message(100);
        }
    }
}