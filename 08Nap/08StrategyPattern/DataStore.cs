using System;
using System.Linq;

namespace _08StrategyPattern
{
    public class DataStore
    {
        private int[] data;

        public DataStore(int[] data)
        {
            this.data = data;
        }

        public int SumOfOdd()
        {
            var sum = 0;
            foreach (var d in data)
            {
                //% az egész osztás jele, ha 2-vel osztva maradékul 1-et ad, akkor páratlan a szám
                if (d % 2 == 1)
                {
                    sum += d;
                }
            }

            return sum;

            //linq kifejezéssel ugyanez:
            //todo:
            //return data.Sum(x => x % 2 == 1);

        }

        public int ProductOfEven()
        {
            var prod = 1;

            foreach (var d in data)
            {
                if (d % 2 == 0)
                {
                    prod *= d;
                }
            }

            return prod;
        }
    }
}