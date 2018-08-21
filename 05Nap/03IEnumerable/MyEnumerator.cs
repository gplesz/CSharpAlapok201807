using System.Collections;
using System.Collections.Generic;

namespace _03IEnumerable
{
    public class MyEnumerator : IEnumerator
    {
        private List<string> shoppingList;

        //jelzi, hogy hol állunk a listában éppen
        //kezdéskor nem mutat sehová

        private int position = -1;

        public MyEnumerator(List<string> shoppingList)
        {
            this.shoppingList = shoppingList;
        }

        /// <summary>
        /// visszaadja az aktuális elemet
        /// </summary>
        public object Current
        {
            get
            {
                var current = shoppingList[position];
                System.Console.WriteLine($"                    Current (position: {position},  current: {current})");
                return current;
            }
        }

        public bool MoveNext()
        {
            //position = position + 1;
            //position += 1;

            position++;
            var moveNext = position < shoppingList.Count;

            System.Console.WriteLine($"                    MoveNext (position: {position}, moveNext: {moveNext})");

            return moveNext;

        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}