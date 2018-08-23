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
    /// <typeparam name="TAdat">
    /// Ilyen típusú adatokat képes az osztály tárolni és karbantartani. Ennek fordítási időben már ki kell derülnie.
    /// </typeparam>
    public class BejarhatoAdatok<TAdat>
    {
        List<TAdat> adatok = new List<TAdat>();

        #region Adatok karbantartására szolgáló felület
        /// <summary>
        /// egy adatcsomagot hozzá tudunk adni a listánkhoz
        /// </summary>
        /// <param name="adat"></param>
        public void Add(TAdat adat)
        {
            adatok.Add(adat);
        }

        /// <summary>
        /// Egy bejegyzés eltávolítása az adatok közül
        /// </summary>
        /// <param name="adat"></param>
        /// <returns></returns>
        public bool Remove(TAdat adat)
        {
            return adatok.Remove(adat);
        }
        #endregion Adatok karbantartására szolgáló felület





    }
}