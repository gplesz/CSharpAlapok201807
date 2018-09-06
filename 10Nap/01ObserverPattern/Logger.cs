using System;

namespace _01ObserverPattern
{
    public class Logger : IMessage
    {
        public void Message(int data)
        {
            Console.WriteLine($"Logger: {data}");
        }
    }
}