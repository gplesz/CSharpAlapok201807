using System;
using System.IO;

namespace _01LocalData
{
    class Program
    {
        static void Main(string[] args)
        {
            //A Path a statikus osztály az elérési utakkal kapcsolatos dolgokban segít.

            //általában érdemes tartózkodni az abszolút elérési utaktól, helyette relatív elérési utat érdemes használni.

            //például: relatív elérési út
            var path = "EgyikKonyvtar";

            //és abszolút elérési út
            Console.WriteLine($"Ennek a relatív könyvtárnak: {path}");
            Console.WriteLine($" ez az abszolút elérési útja: {Path.GetFullPath(path)}");




            Console.ReadLine();
        }
    }
}
