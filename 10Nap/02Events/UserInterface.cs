using System;

namespace _01ObserverPattern
{
    public class UserInterface
    {
        public void Message(object sender, EventDto e)
        {
            //részletes adatoknál kell a típuskonverzió
            var data = (LongRunningProcess)sender;
            //de ha csak a kiemelt adatokra van szükség
            Console.WriteLine($"UserInterface: {e.Data}");
        }
    }
}