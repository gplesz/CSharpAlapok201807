namespace _01IEnumerableT
{
    /// <summary>
    /// Egyszerű adatokat tartalmazó osztály
    /// 
    /// ez lehetne egy könyvtár, egy naptárbejegyzés, stb.
    /// </summary>
    public class Adat
    {

        public int Szam { get; set; }
        public string Szoveg { get; set; }

        public Adat(int szam, string szoveg)
        {
            Szam = szam;
            Szoveg = szoveg;
        }
    }
}