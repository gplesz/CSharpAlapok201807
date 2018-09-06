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
        private readonly IMessage[] observers;

        public LongRunningProcess(params IMessage[] observers)
        {
            this.observers = observers ?? throw new ArgumentNullException(nameof(observers));
        }

        public void Start()
        {
            Console.WriteLine("LongRunningProcess: 0%");

            //todo: értesíteni a kíváncsiskodókat (Observer)
            SendMessage(0);

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 25%");
            SendMessage(25);

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 50%");
            SendMessage(50);

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 75%");
            SendMessage(75);

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 100%");
            SendMessage(100);
        }

        /// <summary>
        /// értesítjük az összes megfigyelőt
        /// </summary>
        /// <param name="data">az információ, amit küldenem kell</param>
        private void SendMessage(int data)
        {
            foreach (var observer in observers)
            {
                observer.Message(data);
            }
        }
    }
}