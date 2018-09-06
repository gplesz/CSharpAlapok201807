using System;

namespace _01ObserverPattern
{
    public class Logger
    {
        public void Message(object sender, EventDto e)
        {
            //részletes adatoknál kell a típuskonverzió
            var data = (LongRunningProcess)sender;
            //de ha csak a kiemelt adatokra van szükség
            Console.WriteLine($"Logger: {e.Data}");
        }
    }
}