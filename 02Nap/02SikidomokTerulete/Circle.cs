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

        public double Area()
        {
            return 2 * radius * Math.PI;
        }
    }
}