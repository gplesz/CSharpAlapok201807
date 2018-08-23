using System;
using System.Collections;
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
    /// 
    /// Ráadásul a saját bejárható osztálya IS (megvalósítja az IEnumerable<T> felületet
    /// 
    /// Ráadásul a saját bejáró osztálya IS (megvalósítja az IEnumerator<T> felületet</T>
    /// 
    /// </summary>
    /// <typeparam name="TAdat">
    /// Ilyen típusú adatokat képes az osztály tárolni és karbantartani. Ennek fordítási időben már ki kell derülnie.
    /// </typeparam>
    public class BejarhatoAdatok<TAdat> : IEnumerable<TAdat>, IEnumerator<TAdat>
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

        #region IEnumerable<TAdat> implementáció
        public IEnumerator<TAdat> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
        #endregion IEnumerable<TAdat> implementáció

        #region IEnumerator<T> implementáció

        public TAdat Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion IEnumerator<T> implementáció

    }
}