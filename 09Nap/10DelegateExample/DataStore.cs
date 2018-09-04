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
            ///for ciklus kell, mert a foreach ciklus
            ///bejárót használ a List osztály példányán, 
            ///így amíg a ciklus tart nem módosíthatom
            ///a lista állapotát
            for (int i = 0; i < lines.Count; i++)
            {
                //kivesszük a lista elem érték
                var item = lines[i];
                //ezt beküldjük a híváslistának
                processList(ref item);
                //a módosított értéket visszaírjuk a listába
                lines[i] = item;
            }
        }


    }
}