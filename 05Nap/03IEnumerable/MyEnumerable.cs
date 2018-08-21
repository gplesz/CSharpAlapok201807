using System.Collections;
using System.Collections.Generic;

namespace _03IEnumerable
{
    public class MyEnumerable : IEnumerable
    {
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