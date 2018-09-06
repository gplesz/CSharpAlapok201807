using System;

namespace _01ObserverPattern
{
    public class UserInterface : IMessage
    {
        public void Message(int data)
        {
            Console.WriteLine($"UserInterface: {data}");
        }
    }
}