using System;

namespace _02SikidomokTerulete
{
    public class Circle : Plane
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
            this.Name = "Kör";
        }

        public override double Area()
        {
            return 2 * radius * Math.PI;
        }
    }
}