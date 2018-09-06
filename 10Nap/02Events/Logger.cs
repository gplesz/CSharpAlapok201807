using System;

namespace _01ObserverPattern
{
    public class Logger
    {
        public void Message(IMessage data)
        {
            Console.WriteLine($"Logger: {data.Data}");
        }
    }
}