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
        int position = -1;

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
        /// <summary>
        /// A bejárót is ez az osztály valósítja meg, így visszaadjuk ezt a példányt 
        /// </summary>
        /// <returns>a BejarhatoAdatok példány, amiben az adatok vannak</returns>
        public IEnumerator<TAdat> GetEnumerator()
        {
            return this;
        }

        /// <summary>
        /// Az IEnumerator előtag segít megkülönböztetni a két felület ugyanolyan szignatúrájú függvényét
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
        #endregion IEnumerable<TAdat> implementáció

        #region IEnumerator<T> implementáció

        /// <summary>
        /// visszaadjuk az aktuális elemet
        /// </summary>
        public TAdat Current { get { return adatok[position]; } }

        /// <summary>
        /// Mivel a funkció már implementálva van generikusan,
        /// így csak meg kell hvni.
        /// 
        /// Az IEnumerator előtag segít megkülönböztetni a két felület ugyanolyan szignatúrájú property getterét
        /// </summary>
        object IEnumerator.Current { get { return Current; } }

        public bool MoveNext()
        {
            position++;
            return position < adatok.Count;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Mivel a generikus osztály minden alkalommel egy másik osztálytípust tartalmaz, 
        /// így az lehet, hogy IDisposable és lehet, hogy nem. Erre csak úgy lehet felkészülni, 
        /// hogy eleve megvalósítjuk az IDisposable felületet.
        /// </summary>
        public void Dispose()
        {
            //mivel most nincs takarítani valónk, így ezt nem kell implementálnunk.
        }

        #endregion IEnumerator<T> implementáció

    }
}