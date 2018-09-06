using System;
using System.Collections.Generic;
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
        private readonly List<IMessage> observers = new List<IMessage>();

        /// <summary>
        /// A megfigyelők listájára történő feliratkozást intézi
        /// </summary>
        /// <param name="observer">feliratkozandó osztály</param>
        public void Subscribe(IMessage observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// A megfigyelők listájáról történő leiratkozást intézi
        /// </summary>
        /// <param name="observer">leiratkozandó osztály</param>
        public void Unsubscribe(IMessage observer)
        {
            observers.Remove(observer);
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