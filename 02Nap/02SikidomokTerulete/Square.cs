using System;

namespace _02SikidomokTerulete
{
    public class Square : Plane
    {
        private int side;

        public Square(int side)
        {
            this.side = side;
            this.Name = "Négyzet";
        }

        public override double Area()
        {
            return side * side;
        }
    }
}