namespace _08StrategyPattern
{
    /// <summary>
    /// Ebbe az osztályba bezárva implementáljuk a 
    /// páratlan számok összeadását
    /// </summary>
    public class SumOfOddStrategy : IStrategy
    {
        public int Process(int[] data)
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
        }
    }
}