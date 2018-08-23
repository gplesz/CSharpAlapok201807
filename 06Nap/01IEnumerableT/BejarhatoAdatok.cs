using System;
using System.Collections.Generic;

namespace _01IEnumerableT
{
    /// <summary>
    /// Adatcsomagokat tárolni és karbantartani képes osztály, 
    /// ami lehetővé teszi az adatcsomagok bejárását foreach 
    /// ciklus segítségével
    /// 
    /// Ráadásul a generikus definíció használatával tetszóleges típust 
    /// képes (szigorúan típusos módon) használni.
    /// </summary>
    public class BejarhatoAdatok
    {
        List<Adat> adatok = new List<Adat>();

        #region Adatok karbantartására szolgáló felület
        /// <summary>
        /// egy adatcsomagot hozzá tudunk adni a listánkhoz
        /// </summary>
        /// <param name="adat"></param>
        public void Add(Adat adat)
        {
            adatok.Add(adat);
        }

        /// <summary>
        /// Egy bejegyzés eltávolítása az adatok közül
        /// </summary>
        /// <param name="adat"></param>
        /// <returns></returns>
        public bool Remove(Adat adat)
        {
            return adatok.Remove(adat);
        }
        #endregion Adatok karbantartására szolgáló felület





    }
}