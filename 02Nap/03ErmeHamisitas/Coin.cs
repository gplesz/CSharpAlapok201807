using System;

namespace _03ErmeHamisitas
{
    public class Coin
    {
        Random random = new Random();

        public int Collect()
        {
            return random.Next(0, 2);
        }
    }
}