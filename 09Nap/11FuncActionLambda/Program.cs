using System;

namespace _11FuncActionLambda
{
    class Program
    {
        delegate int SquaringDef(int x); //négyzetre emlés delegate def (1)

        static void Main(string[] args)
        {
            // a delegate használatának 4 lépése
            // 1. delegate definíció
            // 2.a. függvény definíció
            // 2.b. híváslista definíció és feltöltés
            // 3. híváslista hívása

            SquaringDef squaringProcesslist = SquaringFunc; //(2.b)

            //nem ellenőrzüm a híváslista definiáltságát
            Console.WriteLine($"2 a négyzeten: {squaringProcesslist(2)}");

            //Feladat: hogy tudjuk ezt négy lépést csökkenteni???

            //////////////////////////////
            //1. csökkentő lépés: a lambda
            //////////////////////////////

            //lambda kifejezés használatával a 2.a/2.b lépést egy lépésre tudjuk csökkenteni

            //a lambda kifejezés (=>) egy soron belüli függvénydefiníció
            //a baloldalán a paraméterek listája van zárójelben, vesszővel elválasztva,
            //a jobboldalán pedig a függvény törzse van.

            //a függvény neve úgyis hivatkozásnak kellett, mivel a lambdát oda írjuk,
            //ahol hivatkoznánk a függvény neve már nem is kell

            //ha egy paraméter van, ÉS csak egy kifejezést használok akkor nem kellenek zárójelek () {}
            squaringProcesslist = x => x * x;

            //ugyanez kódblokkban:
            squaringProcesslist = (x) => { return x * x; };
            //kódblokkban akárhány sort használhatok már:

            squaringProcesslist = (x) => 
            {
                Console.WriteLine($"négyzetre emelek, paraméter: {x}");
                return x * x;
            };

            Console.WriteLine($"2 a négyzeten: {squaringProcesslist(2)}");

            Console.ReadLine();
        }

        /// <summary>
        /// 2.a.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static int SquaringFunc(int x)
        {
            return x * x;
        }



    }
}
