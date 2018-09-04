using System;
using System.Collections.Generic;

namespace _10DelegateExample
{
    class Program
    {
        static string CharToRemove = "m";

        static void Main(string[] args)
        {

            var lines = new List<string>();
            lines.Add("Első elem");
            lines.Add("Második elem");
            lines.Add("Harmadik elem");
            lines.Add("Negyedik elem");
            lines.Add("Ötödik elem");
            lines.Add("Hatodik elem");

            var store = new DataStore(lines);

            //store.ProcessData(RemoveA);
            //store.ProcessData(RemoveE);

            //a híváslistán nem "csak" a függvények definíciója, hanem a "környezete" is utazik,
            //hivatkozhatok lokális változóra, és a megy a híváslista "mellett"
            
            //store.ProcessData(RemoveChar);

            //a híváslista végighívása egymás után történik,
            //és ugyanazokkal a paraméterváltozókkal
            //így a ref-el átadott változó is ugyanaz,
            //ezért több műveletet is el tudok végezni.

            //a korábbi műveleteket úgy is el tudom intézni, 
            //hogy a hívásokat felpakolom egy listára, és a listát adom át
            DataStore.FuncDef processList = null;

            store.ProcessData(processList);

            //pl:
            //processList = RemoveA;

            //pl:
            //processList = processList+RemoveE+RemoveChar;

            //vagy:

            processList = delegate { }; //ezzel egy üres híváslistát definiálok, típus nélkül működik

            processList += RemoveA;
            processList += RemoveE;

            //a hivatkozást viszi magával a híváslista
            processList += RemoveChar;

            //ha ez közben változik, akkor kihat a működésre
            CharToRemove = "l";

            //hogy ha lokális változót szeretnénk beküldeni a függvénybe, 
            //akkor remekül használható a külön függvénydefiníció helyett, az un anonymus delegate használata:

            processList += delegate (ref string toModify)
            {
                var toReplace = "d";

                toModify = toModify.Replace(toReplace, "");
            };

            //a kódblokkon belül definiált függvény hozzáfér a kódblokkon belül látható változókhoz
            var toReplaceVar = "k";

            processList += delegate (ref string toModify)
            {
                toModify = toModify.Replace(toReplaceVar, "");
            };

            store.ProcessData(processList);

            store.Print();

            Console.ReadLine();
        }

        private static void RemoveA(ref string text)
        {
            //a Replace függvény nem módosítja a text értékét, 
            //hanem egy új szövegpéldányt hoz létre
            //így az eredményt visszaírjuk a text változóba
            text = text.Replace("a", "");
        }

        private static void RemoveE(ref string text)
        {
            text = text.Replace("e", "");
        }

        private static void RemoveChar(ref string text)
        {
            //kívülről jövő paramétert is használhatok a 
            //delegate-nél: amit a definíció lát, az "megy a híváslistával"
            text = text.Replace(CharToRemove, "");
        }

    }
}
