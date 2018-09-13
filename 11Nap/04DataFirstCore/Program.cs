using _04DataFirstCore.Models;
using System;
using System.Linq;

namespace _04DataFirstCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new CodeFirstDBContext();

            Console.WriteLine($"Tanár: {db.Teachers.Count()}, Tantárgy: {db.Subjects.Count()}");

            Console.ReadLine();

        }
    }
}
