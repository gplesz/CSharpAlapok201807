using System;

namespace _01ObserverPattern
{
    public class Logger
    {
        public void Message(int data)
        {
            Console.WriteLine($"Logger: {data}");
        }
    }
}