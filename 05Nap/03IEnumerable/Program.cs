using System;
using System.Collections.Generic;

namespace _03IEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            var myEnumerable = new MyEnumerable();

            foreach (var item in myEnumerable)
            {
                Console.WriteLine(item);
            }

            //                    MoveNext(position: 0, moveNext: True)
            //                    Current(position: 0, current: 1 kg marhahús)
            //1 kg marhahús
            //                    MoveNext(position: 1, moveNext: True)
            //                    Current(position: 1, current: só)
            //só
            //                    MoveNext(position: 2, moveNext: True)
            //                    Current(position: 2, current: 1 kg burgonya)
            //1 kg burgonya
            //                    MoveNext(position: 3, moveNext: True)
            //                    Current(position: 3, current: 1 kg liszt)
            //1 kg liszt
            //                    MoveNext(position: 4, moveNext: False)

            //a fordító egy ilyet gyárt:

            Console.WriteLine();
            Console.WriteLine();

            var enumerator = myEnumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                //ez lesz a ciklus változója

                Console.WriteLine(current);
            }

            //figyelem, nekünk kell az implementációban azzal foglalkozni,
            //ha az adatok megváltoztak !!!
            //példa: a List implementációja

            //ez a könnyebb megoldás: ha változik a lista, akkor dob egy kivételt.
            //a nehezebb: a saját osztályunk gondokodik arról, hogyha változik a belső állapot, akkor a futó
            //bejárások ne fussanak hibás helyzetbe
            //A List<T> ezt úgy oldja meg, hogy kivételt dob, ha módosítani akarok bejárás közben.
            //System.InvalidOperationException: 'Collection was modified; enumeration operation may not execute.'
            var shoppingList = new List<string>() { "1 kg marhahús", "só", "1 kg burgonya", "1 kg liszt" };

            foreach (var item in shoppingList)
            {
                shoppingList.Remove(item);
            }

            Console.ReadLine();
        }
    }
}
