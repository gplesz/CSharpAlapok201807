using System;

namespace _01ObserverPattern
{
    public class UserInterface
    {
        public void Message(IMessage data)
        {
            Console.WriteLine($"UserInterface: {data.Data}");
        }
    }
}