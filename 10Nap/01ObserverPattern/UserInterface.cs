using System;

namespace _01ObserverPattern
{
    public class UserInterface : INotifiable
    {
        public void Message(IMessage data)
        {
            Console.WriteLine($"UserInterface: {data}");
        }
    }
}