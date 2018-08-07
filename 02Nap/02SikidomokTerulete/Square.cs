using System;

namespace _02SikidomokTerulete
{
    public class Square : IPlane
    {
        private int side;

        public Square(int side)
        {
            this.side = side;
        }

        public double Area()
        {
            return side * side;
        }
    }
}