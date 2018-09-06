using System;

namespace _01ObserverPattern
{
    /// <summary>
    /// Esemény DTO
    /// 
    /// a konstruktort érdemes implementálni
    /// </summary>
    public class EventDto : EventArgs
    {
        public int Data;

        public EventDto(int data)
        {
            this.Data = data;
        }
    }
}