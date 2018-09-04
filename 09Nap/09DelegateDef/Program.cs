using System;

namespace _09DelegateDef
{
    class Program
    {
        /// <summary>
        /// 1. lépés: megadjuk 
        ///   a függvény visszatérési értékét, 
        ///   szignatúráját 
        ///   és egy nevet, hivatkozásnak.
        ///   
        ///   típusdefiníció: leírjuk, hogy milyen függvényre gondoltunk.
        /// </summary>
        /// <param name="msg"></param>
        delegate void DelegateDef(string msg);

        /// <summary>
        /// egyik függvény, amire illik a leírás
        /// 
        /// azért static, mert majd a Main-ből fogjuk hívni, 
        /// ami static, ennek nincs köze a delegate témakörhöz.
        /// </summary>
        /// <param name="txt"></param>
        static void Hi(string txt)
        {
            Console.WriteLine($"Szia, de jó, hogy jössz: {txt}");
        }


        /// <summary>
        /// másik függvény, amire illik a leírás
        /// 
        /// azért static, mert majd a Main-ből fogjuk hívni, 
        /// ami static, ennek nincs köze a delegate témakörhöz.
        /// </summary>
        /// <param name="str"></param>
        static void By(string str)
        {
            Console.WriteLine($"Szia, kár, hogy már mész: {str}");
        }


        static void Main(string[] args)
        {
            DelegateDef a;
            DelegateDef b;
            DelegateDef c;
            DelegateDef d;

            //csinálok egy híváslistát, 
            //ami egy hivatkozást tartalmaz
            a = Hi;

            //csinálok egy másik híváslistát, 
            //ami egy hivatkozást tartalmaz
            b = By;

            //ezeket a híváslitákat össze tudom fűzni
            c = a + b;

            //ezeknek a híváslistáknak tudom venni a különbségét
            d = c - a;

            /// jön a harmadik lépés: meghívjuk a híváslistákat:
            /// 
            Console.WriteLine("meghívjuk az [a] listát");
            a("a");

            Console.WriteLine("meghívjuk az [b] listát");
            b("b");

            Console.WriteLine("meghívjuk az [c] listát");
            c("c");

            Console.WriteLine("meghívjuk az [d] listát");
            d("d");

            Console.ReadLine();

            /// Eremény:
            /// 
            //meghívjuk az[a] listát
            //Szia, de jó, hogy jössz: a
            //meghívjuk az[b] listát
            //Szia, kár, hogy már mész: b
            //meghívjuk az[c] listát
            //Szia, de jó, hogy jössz: c
            //Szia, kár, hogy már mész: c
            //meghívjuk az[d] listát
            //Szia, kár, hogy már mész: d

        }
    }
}
