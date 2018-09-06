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
            Data = 0;

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 25%");
            Data = 25;

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 50%");
            Data = 50;

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 75%");
            Data = 75;

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 100%");
            Data = 100;
        }

        private int data;
        public int Data
        {
            get { return data; }
                
            set
            {
                if (data == value) { return; } //ha nem változott, akkor "ne pánikoljunk"

                data = value;
                //todo: értesíteni a kíváncsiskodókat (Observer)
                SendMessage();
            }
        }

        //ha szeretnénk több információt megosztani
        //a figyelőkkel, akkor ezt fel kell venni 
        //a felületbe és készen is vagyunk
        public string Text { get; set; }

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