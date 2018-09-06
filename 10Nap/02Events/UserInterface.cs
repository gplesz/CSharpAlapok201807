using System;

namespace _01ObserverPattern
{
    public class UserInterface
    {
        internal void Message(object sender, string e)
        {
            var data = (LongRunningProcess)sender;
            Console.WriteLine($"UserInterface: {data.Data}");
        }
    }
}