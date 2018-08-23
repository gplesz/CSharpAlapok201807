using System.Collections;
using System.Collections.Generic;

namespace _03IEnumerable
{
    public class MyEnumerable : IEnumerable
    {
        //mivel az adatok kívülről nem módosíthatóak, ezért nincs az a veszély, hogy bejárás közben 
        //módosulnának. Ha van módosító felületünk, akkor figyelni kell, hogy bejárás közben vagyunk.
        List<string> shoppingList = new List<string>() { "1 kg marhahús", "só", "1 kg burgonya", "1 kg liszt" };

        public MyEnumerable()
        {
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(shoppingList);
        }
    }
}