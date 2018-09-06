using System;

namespace _01ObserverPattern
{
    public class Logger
    {
        internal void Message(object sender, string e)
        {
            var data = (LongRunningProcess)sender;
            Console.WriteLine($"Logger: {data.Data}");
        }
    }
}