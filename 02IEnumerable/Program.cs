using System;
using System.Collections.Generic;

namespace _02IEnumerable
{
    class Program
    {

        /// <summary>
        /// A static kulcsszóval jelölt propertyk, field-ek és method-ok az osztály definícióhoz tartoznak.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            foreach (var item in ShoppingList())
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        private static IEnumerable<string> ShoppingList()
        {
            yield return "1 kg marhahús";
            yield return "só";
            yield return "1 kg burgonya";
            yield return "1 kg liszt";


            //statikus függvényből statikus függvényt hívhatok:
            //ShoppingList();
            //Main(new string[] { });


            //Azonban példányszintű függvényt nem
            //InstanceFunction();

        }

        public void InstanceFunction()
        {
            //példányszintű függvényből hívhatok példányszintűt, mert ezen a példányon belülit jelenti
            InstanceFunction();
            //illetve statikust is, mert abból pedig egy van 
            ShoppingList();
            Main(new string[] { });
        }

    }
}
