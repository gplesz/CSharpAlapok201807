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
            squaringProcesslist = y => y * y;

            //ugyanez kódblokkban:
            squaringProcesslist = (x) => { return x * x; };
            //kódblokkban akárhány sort használhatok már:

            squaringProcesslist = (integerNum) => 
            {
                Console.WriteLine($"négyzetre emelek, paraméter: {integerNum}");
                return integerNum * integerNum;
            };

            Console.WriteLine($"2 a négyzeten: {squaringProcesslist(2)}");

            /////////////////////////////////////
            //2. csökkentő lépés: Action és Func
            /////////////////////////////////////

            //az Action és a Func előre definiált delegate, amik segítenek az 1. pont eliminálásában.
            //
            //az Action<> egy void típusú delegate-et definiálni
            //mivel visszatérő értékre nincs szükség (void)
            //névre nincs szükség (az Action-t oda írom, ahova a nevet írnám, az csak egy hivatkozés
            //a paraméterek neve csak formális, 
            //itt amire szükségem van, az a paraméterek típusának felsorolása

            // az
            // Action<T1,T2,...,TN> 
            // az egyenértékű a  
            // delegate void XXX(T1 t1, T2 t2, ... , T3 t3) 
            // definícióval, amit a .NET környezet fejlesztői elhelyeztek előre az objektumkönyvtárba.

            Action<int, int> multiplicationProcessList = (a, b) => Console.WriteLine($"A szorzás eredménye: {a * b}");

            //vagy kódblokkal:
            multiplicationProcessList = (a, b) => 
            {
                Console.WriteLine($"A szorzás eredménye: {a * b}");
            };

            //a nulla bejövő paramétertől a 16 bejövő paraméterig ez a .NET környezet része:
            //Action 
            //Action<int, int, int, ... int>




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
