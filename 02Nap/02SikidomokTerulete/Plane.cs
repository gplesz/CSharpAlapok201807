using System;

namespace _02SikidomokTerulete
{
    //abstract függvényt csak abstract osztályban lehet létrehozni, ezért abstract
    public abstract class Plane : IPlane
    {
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