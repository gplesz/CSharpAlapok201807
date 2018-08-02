using System;

namespace _03ErmeHamisitas
{
    public class Coin
    {
        public Coin()
        {
            Console.WriteLine("Coin konstruktor");
        }

        Random random = new Random();

        //a virtual kulcsszóval engedélyezem a hamísítást
        public virtual int Collect()
        {
            Console.Write("Coin.Collect()");
            return random.Next(0, 2);
        }
    }
}