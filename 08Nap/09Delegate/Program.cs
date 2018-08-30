using System;

namespace _09Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            var storeWithDelegate = new DataStoreWithDelegate(data: new int[] { 1, 3, 4, 5, 7, 8, 10, 15, 30 });

            ///1. definiálni kell egy delegate típust (ProcessDef) (Hívott oldal)
            ///2. definiálni kell egy függvényt, ami megfelel a delegate-nek (SumOfOdd) (hívó oldal)
            ///3. fogadni kell a felhasználás helyén egy változóval a függvényt Process(ProcessDef strategy) (hívott oldal)
            ///4. be kell küldeni a függvényt felhasználásra (hívó oldal)
            var sum = storeWithDelegate.Process(SumOfOdd);
            Console.WriteLine($"Páratlanok összege: {sum}");

            //Első egyszerűsítés: hívott oldalon delegate + paraméter átvétel helyett Func<> definíció a Process2 függvényben
            ///1. át kell venni egy megfelelő függvényt: Func<int[], int> (Fogadó oldal)
            ///2. definiálni kell egy függvényt, ami megfelel a delegate-nek (SumOfOdd) (hívó oldal)
            ///3. be kell küldeni a függvényt felhasználásra (hívó oldal)
            sum = storeWithDelegate.Process2(SumOfOdd);
            Console.WriteLine($"Páratlanok összege: {sum}");

            //Második egyszerűsítés
            //1. át kell venni egy megfelelő függvényt: Func<int[], int> (Fogadó oldal)
            //2. beküldjük a LAMBDA kifejezéssel a soron belül definiált függvényünket
            sum = storeWithDelegate.Process3(data => 
            {
                var s = 0;
                foreach (var d in data)
                {
                    //% az egész osztás jele, ha 2-vel osztva maradékul 1-et ad, akkor páratlan a szám
                    if (d % 2 == 1)
                    {
                        s += d;
                    }
                }

                return s;
            });

            Console.WriteLine($"Páratlanok összege: {sum}");


            Console.ReadLine();

        }

        private static int SumOfOdd(int[] data)
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
