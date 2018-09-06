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
        //definiáljuk az eseményt
        //ami egyben  
        //1. delegate típusdefinicó és
        //2. delegate hiváslista változó deklaráció
        // 
        //
        // ez egy különleges delegate-et definiál:
        // a.) csak void típusú függvényt definiál
        // b.) ezt a híváslistát nem lehet az osztályon kívülről meghívni
        // c.) ezt a híváslistát nem lehet osztályon kívülről inicializálni (= művelet)

        // a függvénynek két paramétere van minden esetben:
        // ha a definíció EventHandler<T> akkor:
        // object sender, 
        //és
        // T e
        //az első kötelező, a másodikat a generikus paraméter jelöli ki
        //ha nem akarok paramétert kiemelni, akkor ez egy üres definíció, 
        //public event EventHandler<EventArgs> DataChanged;

        //különben mindenképpen Dto-t kell definiálni, ami le van származtatva az EventArgs-ból
        public event EventHandler<EventDto> DataChanged;


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
        /// Az eseménylista hívását beburkoljuk egy private függvényba
        /// </summary>
        /// <param name="data"></param>
        private void OnDataChanged(int data)
        {
            var callList = DataChanged;
            if (callList != null)
            {
                //ha nincs kiemelt paraméter, akkor így hívunk:
                //callList(this, EventArgs.Empty);

                callList(this, new EventDto(data));
            }
            //gyorsabban ugyanez
            //ObserversCallList?.Invoke(this);
        }


        /// <summary>
        /// értesítjük az összes megfigyelőt
        /// </summary>
        private void SendMessage()
        {
            OnDataChanged(Data);
        }
    }
}