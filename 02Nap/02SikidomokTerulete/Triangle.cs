using System;

namespace _02SikidomokTerulete
{
    public class Triangle : IPlane
    {
        private int trianglebase;
        private int height;

        public Triangle(int trianglebase, int height)
        {
            this.trianglebase = trianglebase;
            this.height = height;
        }

        public int Area()
        {
            return (trianglebase * height) / 2;
        }
    }
}