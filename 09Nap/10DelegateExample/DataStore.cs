using System;
using System.Collections.Generic;

namespace _10DelegateExample
{
    public class DataStore
    {
        private List<string> lines;

        /// <summary>
        /// függvény definíció, hogy a módosító függvény(ek) (stratégiák)
        /// be tudjanak jönni a delegate segítségével
        /// </summary>
        /// 
        public delegate void FuncDef(ref string text);


        public DataStore(List<string> lines)
        {
            this.lines = lines;
        }

        public void Print()
        {
            foreach (var item in lines)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// A módosítást elvégző "felület"
        /// ezen keresztül érkezik a módosítások "listája"
        /// </summary>
        /// <param name="processList">
        /// a delegate hívsálistája, amin minden elem olyan függvényre mutat, 
        /// ami megfelel a FuncDef definíciónak
        /// </param>
        public void ProcessData(FuncDef processList)
        {

            //ez a legerősebb retorzió, abban az esetben, hogyha a listánk nem lehet üres.
            //azonban a híváslista nem thread safe, így amíg mi olvassuk, addig más írhatja
            //ekkor, ha valaki éppen leiratkozik a híváslistáról, amíg mi kiolvassuk
            //most lehet, hogy nem üres, azonban mire felhasználnánk, már lehet, hogy üres LESZ.
            //if (processList == null)
            //{
            //    throw new ArgumentNullException(nameof(processList));
            //}

            /////////////////////////////////////////////////
            //ezért a korábbiak helyett ezt érdemes használni
            /////////////////////////////////////////////////

            //értéktípusként a teljes lista lemásolódik
            var processListBackup = processList;
            if (processListBackup==null)
            { //mivel ez a lista itt lokális, más szál nem fér hozzá, így az értéke 
              //(a rajta szereplő függvény hivatkozások értéke)
              //nem változik meg más szálon
                throw new ArgumentNullException(nameof(processList));
                //vagy nem csinálunk semmit
                //return;
            }

            ///for ciklus kell, mert a foreach ciklus
            ///bejárót használ a List osztály példányán, 
            ///így amíg a ciklus tart nem módosíthatom
            ///a lista állapotát
            for (int i = 0; i < lines.Count; i++)
            {
                //kivesszük a lista elem érték
                var item = lines[i];
                //ezt beküldjük a híváslistának


                //közvetlenül a hívás előtt is végezhetünk null vizsgálatot:
                //akár ebben a formában is:
                //processList?.Invoke(ref item);

                //ez ugyanez mint ez:
                var procList = processList;
                if (procList!=null)
                {
                    processList(ref item);
                }

                //a módosított értéket visszaírjuk a listába
                lines[i] = item;
            }
        }


    }
}