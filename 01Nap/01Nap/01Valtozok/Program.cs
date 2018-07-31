namespace _01Valtozok
{
    class Program
    {
        static void Main(string[] args)
        {
            //értéktípusok

            //a jobboldalon kialakuló érték típusának megfelelő változót hozunk létre
            var ertek1 = 10;

            //ezt helyettesítjük
            //int ertek1 = 10;

            //vagy pontosabban ezt
            //System.Int32 ertek1 = 10;

            var ertek2 = ertek1;

            System.Console.WriteLine($"ertek1: {ertek1}, ertek2: {ertek2}");
            //ertek1: 10, ertek2: 10


            //KÉRDÉS: ezek hogyan viszonyulnak egymáshoz???

            ertek1 = 20;

            System.Console.WriteLine($"ertek1: {ertek1}, ertek2: {ertek2}");
            //ertek1: 20, ertek2: 10

            //ez a két változó teljesen független, amikor az egyik másolja a másikat, 
            //var ertek2 = ertek1;
            //akkor egy új jön létre, és az értékét másolja le


            //ÉRTÉKTÍPUS esetén az értékadás működése:
            //minden alkalommal létrejön egy új változó az egyenlőségjel baloldalán álló értékkel,
            //és ez az új változó kerül a baloldalon álló változóhivatkozásba.

            //értéktípusok: promitív típusok, számok, logikai értékek, enum.


            //referenciatípus
            var referencia1 = new SajatReferencia();
            referencia1.ertek = 10;


            var referencia2 = referencia1;

            System.Console.WriteLine($"referencia1.ertek: {referencia1.ertek}, referencia2.ertek: {referencia2.ertek}");
            //referencia1.ertek: 10, referencia2.ertek: 10

            //KÉRDÉS: ezek hogyan viszonyulnak egymáshoz???
            referencia1.ertek = 20;
            System.Console.WriteLine($"referencia1.ertek: {referencia1.ertek}, referencia2.ertek: {referencia2.ertek}");
            //referencia1.ertek: 20, referencia2.ertek: 20

            //REFERENCIATÍPUS esetén az értékadás működése
            //az egyenlőségjel jobboldalán álló kifejezés értékét
            //beírja a baloldali változóba

            //összetett _beépített_ típusok példái:

            //számokból álló tömb
            //ez az írásmód ugyanazt az eredményt adja, mint az előző
            //int[] tomb1 = { 0 };
            var tomb1 = new int[] { 10 };

            var tomb2 = tomb1;

            System.Console.WriteLine($"tomb1: {tomb1[0]}, tomb2: {tomb2[0]}");
            //tomb1: 10, tomb2: 10
            tomb1[0] = 20;

            System.Console.WriteLine($"tomb1: {tomb1[0]}, tomb2: {tomb2[0]}");
            //tomb1: 20, tomb2: 20
            //Tehát: a tömb típus, az refenciatípus

            //karakterekből álló tömb, "teljes" definíció
            var szoveg1 = new string(new char[] { '1', '0' });

            //valójában ezt használjuk
            //var szoveg1 = "10";

            var szoveg2 = szoveg1;

            System.Console.WriteLine($"szoveg1: {szoveg1}, szoveg2: {szoveg2}");
            //szoveg1: 10, szoveg2: 10

            szoveg1 = "20";

            System.Console.WriteLine($"szoveg1: {szoveg1}, szoveg2: {szoveg2}");
            //szoveg1: 20, szoveg2: 10

            //vagyis: a szöveg ÉRTÉKTÍPUSKÉNT viselkedik!!!


            //saját összetett értéktípus

            var sajatertek1 = new SajatErtek();
            sajatertek1.ertek = 10;
            sajatertek1.referencia = new SajatReferencia { ertek = 10 };


            //az előző definíció megegyezik ezzel
            //var sajatertek1 = new SajatErtek
            //{
            //    ertek = 10
            //};

            var sajatertek2 = sajatertek1;

            System.Console.WriteLine($"sajatertek1.ertek: {sajatertek1.ertek}, sajatertek2.ertek: {sajatertek2.ertek}");
            //sajatertek1.ertek: 10, sajatertek2.ertek: 10
            System.Console.WriteLine($"sajatertek1.referencia.ertek: {sajatertek1.referencia.ertek}, sajatertek2.referencia.ertek: {sajatertek2.referencia.ertek}");
            //sajatertek1.referencia.ertek: 10, sajatertek2.referencia.ertek: 10

            sajatertek1.ertek = 20;
            sajatertek1.referencia.ertek = 20;

            System.Console.WriteLine($"sajatertek1.ertek: {sajatertek1.ertek}, sajatertek2.ertek: {sajatertek2.ertek}");
            //sajatertek1.ertek: 20, sajatertek2.ertek: 10
            System.Console.WriteLine($"sajatertek1.referencia.ertek: {sajatertek1.referencia.ertek}, sajatertek2.referencia.ertek: {sajatertek2.referencia.ertek}");
            //sajatertek1.referencia.ertek: 20, sajatertek2.referencia.ertek: 20

            //vagyis, a struct kulcsszóval létrehozott változó értéktípusként viselkedik
            //DE az értéktípusban szereplő referenciatípus TOVÁBBRA IS referenciatípusként viselkedik!!!


            //várunk a végén egy enter lenyomására
            System.Console.ReadLine();

        }
    }
}
