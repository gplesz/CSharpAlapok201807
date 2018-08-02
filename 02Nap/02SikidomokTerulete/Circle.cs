using System;

namespace _02SikidomokTerulete
{
    public class Circle : IPlane
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public int Area()
        {
            return (int)(2 * radius * Math.PI);
        }
    }
}