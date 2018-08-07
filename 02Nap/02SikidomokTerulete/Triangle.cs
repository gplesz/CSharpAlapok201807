using System;

namespace _02SikidomokTerulete
{
    public class Triangle : Plane
    {
        private int trianglebase;
        private int height;

        public Triangle(int trianglebase, int height)
        {
            this.trianglebase = trianglebase;
            this.height = height;
            this.Name = "Háromszög";
        }

        public override double Area()
        {
            return (trianglebase * height) / 2;
        }
    }
}