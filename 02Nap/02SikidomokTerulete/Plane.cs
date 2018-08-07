using System;

namespace _02SikidomokTerulete
{
    //abstract függvényt csak abstract osztályban lehet létrehozni, ezért abstract
    public abstract class Plane : IPlane
    {
        /// <summary>
        /// Absztrakt osztályban lehet nem absztrakt property
        /// 
        /// A létrejövő síkidom neve
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// síkidom megjelenítése
        /// </summary>
        public void Show()
        {
            //todo: a síkidom megjelenítését végző függvény implementációja
        }

        /// <summary>
        /// síkidom eltöntetése
        /// </summary>
        public void Hide()
        {
            //todo: eltüntetés implementációja
        }


        //mivel nincs általános síkidom területszámítás, így 
        //ide nem tudunk érvényes implementációt adni.
        //erre való az absztrakt függvény, aminek nincs implementációja
        //mivel nincs implementációja, arra való, hogy a leszármaztatás közben implementáljuk
        //vagyis az abstract kulcsszó gyakorlatilag egyben jelenti a virtual
        //további kötelmek:
        //abstract függvényt csak abstract osztályban lehet létrehozni

        public abstract double Area();
    }
}