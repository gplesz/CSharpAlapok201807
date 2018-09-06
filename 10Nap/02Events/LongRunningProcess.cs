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
        //Ilyen értesítést tudunk hívni, így ilyeneket engedünk a híváslistára
        public delegate void MessageDef(IMessage data);

        //ez pedig a híváslistánk:
        public MessageDef ObserversCallList;

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
            var callList = ObserversCallList;
            if (callList != null)
            {
                callList(this);
            }
            //gyorsabban ugyanez
            //ObserversCallList?.Invoke(this);

        }
    }
}