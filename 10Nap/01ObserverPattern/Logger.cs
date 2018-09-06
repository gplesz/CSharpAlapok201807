using System;

namespace _01ObserverPattern
{
    public class Logger : INotifiable
    {
        public void Message(IMessage data)
        {
            Console.WriteLine($"Logger: {data.Data}");
        }
    }
}