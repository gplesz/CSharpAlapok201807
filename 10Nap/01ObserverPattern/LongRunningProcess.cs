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
    public class LongRunningProcess : IMessage
    {
        private readonly List<INotifiable> observers = new List<INotifiable>();

        /// <summary>
        /// A megfigyelők listájára történő feliratkozást intézi
        /// </summary>
        /// <param name="observer">feliratkozandó osztály</param>
        public void Subscribe(INotifiable observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// A megfigyelők listájáról történő leiratkozást intézi
        /// </summary>
        /// <param name="observer">leiratkozandó osztály</param>
        public void Unsubscribe(INotifiable observer)
        {
            observers.Remove(observer);
        }

        public void Start()
        {
            Console.WriteLine("LongRunningProcess: 0%");

            //todo: értesíteni a kíváncsiskodókat (Observer)
            SendMessage();

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 25%");
            SendMessage();

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 50%");
            SendMessage();

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 75%");
            SendMessage();

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 100%");
            SendMessage();
        }

        /// <summary>
        /// értesítjük az összes megfigyelőt
        /// </summary>
        private void SendMessage()
        {
            foreach (var observer in observers)
            {
                observer.Message(this);
            }
        }
    }
}