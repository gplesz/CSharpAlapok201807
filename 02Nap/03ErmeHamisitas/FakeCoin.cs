namespace _03ErmeHamisitas
{
    public class FakeCoin : Coin
    {
        public FakeCoin()
        {
            System.Console.WriteLine("FakeCoin konstruktor");
        }

        //override-dal hamisítjuk a virtual függvényt
        public override int Collect()
        {
            System.Console.Write("FakeCoin.Collect()");
            return 0;
        }
    }
}