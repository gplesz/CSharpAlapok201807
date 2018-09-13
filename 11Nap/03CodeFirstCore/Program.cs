using _03CodeFirstCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03CodeFirstCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=.\\SQLEXPRESS;Database=CodeFirstDB;Trusted_Connection=True;";

            var optionsBuilder = new DbContextOptionsBuilder<CodeFirstContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var db = new CodeFirstContext(optionsBuilder.Options);

            if (db.Teachers.Count() == 0)
            { //adatok ellenőrzése
                Seed(db);
            }

            Console.WriteLine($"A tanárok száma: {db.Teachers.Count()}, a tantárgyak száma: {db.Subjects.Count()}");

            Console.ReadLine();

        }

        private static void Seed(CodeFirstContext db)
        {
            //todo: ellenőrizni kell az adatbázis létezését
            //todo: és ha nem létezik, létre kell hozni.

            var subjects = new List<Subject>();

            subjects.Add(new Subject() { Name = "Matematika" });
            subjects.Add(new Subject() { Name = "Fizika" });

            db.Teachers.Add(new Teacher() { Name = "Matektanár", Subject = subjects });

            db.SaveChanges();
        }
    }
}
