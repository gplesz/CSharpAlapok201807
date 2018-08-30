using System;

namespace _08StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new DataStore(data: new int[] { 1,3,4,5,7,8,10,15,30 });

            //páratlan számok összege
            var sum = store.SumOfOdd();

            Console.WriteLine($"Páratlanok összege: {sum}");

            //páros számok szorzata
            sum = store.ProductOfEven();
            Console.WriteLine($"Párosok szorzata: {sum}");

            //ugyanez stratégia mintával
            var storeWStrategy = new DataStoreWithStrategy(data: new int[] { 1, 3, 4, 5, 7, 8, 10, 15, 30 });

            //példányosítunk egy műveletvégző osztályt
            IStrategy strategy = new SumOfOddStrategy();

            //átadjuk az adatokat tároló osztálynak
            storeWStrategy.SetStrategy(strategy);

            //majd kérjük, hogy végezze el a műveletet
            sum = storeWStrategy.Process();

            Console.WriteLine($"Páratlanok összege: {sum}");

            strategy = new ProductOfEvenStrategy();

            //átadjuk az adatokat tároló osztálynak
            storeWStrategy.SetStrategy(strategy);

            //majd kérjük, hogy végezze el a műveletet
            sum = storeWStrategy.Process();

            Console.WriteLine($"Párosok szorzata: {sum}");

            Console.ReadLine();
        }
    }
}
