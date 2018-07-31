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


            //ezek hogyan viszonyulnak egymáshoz???

            ertek1 = 20;

            System.Console.WriteLine($"ertek1: {ertek1}, ertek2: {ertek2}");
            //ertek1: 20, ertek2: 10

            //ez a két változó teljesen független, amikor az egyik másolja a másikat, 
            //var ertek2 = ertek1;
            //akkor egy új jön létre, és az értékét másolja le


            //értéktípus esetén az értékadás működése:
            //minden alkalommal létrejön egy új változó a balodlai értékkel,
            //és ez az új változó kerül a baloldalon álló változóhivatkozásba.

            //értéktípusok: promitív típusok, számok, logikai értékek, enum.

            System.Console.ReadLine(); 


        }
    }
}
