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
