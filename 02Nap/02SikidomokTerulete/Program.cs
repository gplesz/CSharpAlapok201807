using System;
using System.Collections.Generic;

namespace _02SikidomokTerulete
{
    class Program
    {
        static void Main(string[] args)
        {
            var square = new Square(side: 4);

            //ez helyett:
            //"A négyzet területe: " + square.Area().ToString()
            //stringeket így fűzünk inkább egymáshoz:
            Console.WriteLine($"A négyzet területe: {square.Area()}");

            var circle = new Circle(radius: 5);
            Console.WriteLine($"A kör területe: {circle.Area()}");

            var triangle = new Triangle(trianglebase: 6, height: 4);
            Console.WriteLine($"A háromszög területe: {triangle.Area()}");

            //területek összeadása
            var areasum = square.Area();

            areasum = areasum + circle.Area();

            //az előző műveletet rövidítve így lehet leírni
            areasum += triangle.Area();
            Console.WriteLine($"A területek összege: {areasum}");

            // hogy lehetne ezt profibban elvégezni???
            // mi van, ha 300 síkidom területét kell összeadni?


            var planes = new List<IPlane>();

            planes.Add(square);
            planes.Add(circle);
            planes.Add(triangle);

            var sum = 0;
            foreach (var plane in planes)
            {
                sum += plane.Area();
            }
            Console.WriteLine($"A területek összege: {sum}");


            Console.ReadLine();
        }
    }
}
