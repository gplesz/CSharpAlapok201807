using System;

namespace _01ObserverPattern
{
    public class UserInterface
    {
        public void Message(int data)
        {
            Console.WriteLine($"UserInterface: {data}");
        }
    }
}