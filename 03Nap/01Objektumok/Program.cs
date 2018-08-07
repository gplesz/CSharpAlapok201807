using System;

namespace _01Objektumok
{
    class Program
    {
        static void Main(string[] args)
        {
            var plane1 = new Plane();
            var plane2 = new Plane();

            //Azonosíthatóság: el tudjuk dönteni, hogy két példány azonos-e?
            //a két példányra mutató referencia van a két változóban
            //a vizsgálat azt nézi, hogy a két referencia ugyanoda mutat-e?
            //tartalmat nem ellenőriz, csak referenciát (alapértelmezésben)
            if (plane1==plane2)
            {
                Console.WriteLine("A két példány azonos");
            }
            else
            {
                Console.WriteLine("A két példány NEM azonos");
            }

            //állapot tárolása
            plane1.NrOfEdge = 3;
            plane2.NrOfEdge = 5;

            //ha a private get, akkor ez nem fordul
            //Console.WriteLine(plane1.Data3); 
            plane1.Name = "PLANE1"; //a setter függvényt hívjuk
            Console.WriteLine(plane1.Name); //a gettert hívjuk

            plane1.Show(1, 3);

            //érték szerinti átadás
            var ertek = 2;
            //referencia szerinti átadás
            var referencia = new ReferenciaTipus() { ertek = 3 };

            //tudunk értéktípust referencia szerint átadni
            var ertek2 = 4;

            Console.WriteLine($"ertek: {ertek}, referencia: {referencia.ertek}, ertek2: {ertek2}");

            //amikor az alapértelmezéstől elrtér a paraméterátadás,
            //ezt a hívó oldalon is jelezni kell (ref, out)
            int ertek3;
            plane1.Show(ertek, referencia, ref ertek2, out ertek3);

            //ezt már így is lehet definiálni, egy sorban vs2015-től
            //plane1.Show(ertek, referencia, ref ertek2, out int ertek3);

            Console.WriteLine($"ertek: {ertek}, referencia: {referencia.ertek}, ertek2: {ertek2}, ertek3: {ertek3}");

            //az alapértelmezett értékkel rendelkező paraméterek elhagyhatóak
            plane1.Show(); //figyelem! ez a paraméter nélküli függvényt hívja
            plane1.Show(width: 9, name: "akármi"); //alapértelmezett értéke miatt a height paramétert nem kell megadni, a fordító megtalálja

            Console.ReadLine();

        }
    }
}
