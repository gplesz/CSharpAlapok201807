namespace _08StrategyPattern
{
    public class ProductOfEvenStrategy : IStrategy
    {
        public int Process(int[] data)
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