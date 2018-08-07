using System;

namespace _03ErmeHamisitas
{
    class Program
    {
        static void Main(string[] args)
        {
            var coin = new FakeCoin();

            //mivel a DoCollects Coin típusú paramétert vár, 
            //a háttérben lefut egy típuskonverzió
            //a típuskonverzió azt jelenti, hogy a példányt a Coin felületen keresztül fogjuk használni
            //ez azért tud lefutni, mert a FakeCoin le van származtatva a Coin osztályból

            DoCollects(coin);

            Console.ReadLine();
        }

        private static void DoCollects(Coin coin)
        {
            Console.WriteLine("Az érmefeldobások eredménye:");
            for (int i = 0; i < 100; i++)
            {
                Console.Write($"{coin.Collect()},");
            }
        }
    }
}
