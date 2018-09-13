using System;
using System.Threading;
using System.Threading.Tasks;

namespace _02Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Action todo = () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"i: {i}");
                    Thread.Sleep(300);
                }
            };

            var task = new Task(todo);

            Console.WriteLine($"Státusz: {task.Status}");

            task.Start(); //elindítjuk a feladatot
            Console.WriteLine($"Státusz: {task.Status}");

            Thread.Sleep(100); //kicsit várunk
            Console.WriteLine($"Státusz: {task.Status}");

            task.Wait(); //bevárjuk a feladat végét
            Console.WriteLine($"Státusz: {task.Status}");

            Console.ReadLine();

            //Státusz: Created
            //Státusz: WaitingToRun
            //i: 0
            //Státusz: Running
            //i: 1
            //i: 2
            //i: 3
            //i: 4
            //i: 5
            //i: 6
            //i: 7
            //i: 8
            //i: 9
            //Státusz: RanToCompletion

        }

        /// <summary>
        /// Action helyett így is adhatunk függvéndefiníciót
        /// </summary>
        static public void todo2()
        { }


    }
}
