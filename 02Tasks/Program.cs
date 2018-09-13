using System;
using System.Threading;
using System.Threading.Tasks;

namespace _02Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task státuszok viszgálata
            //Test1();

            //kivételek elkapása
            //Test2();

            //task cancel
            Test3();

            Console.ReadLine();
        }

        private static void Test3()
        {
            var cts = new CancellationTokenSource(); //1. ez egy rádióadó, amit a task menet közben fog

            Action todo = () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    if (cts.Token.IsCancellationRequested)
                    { // 3.a ha kiadtuk a cancel-t, akkor itt tudjuk ezt érvényesíteni 
                        //vagy takarítani magunk után, ld. IDisposable
                        Console.WriteLine("i: Cancel-t kaptunk");
                    }

                    cts.Token.ThrowIfCancellationRequested(); //3.b ezzel lépünk ki a task futásából
                    Console.WriteLine($"i: {i}");
                    Thread.Sleep(100);
                }
            };

            var task = new Task(todo, cts.Token); //2. átadjuk a task-nak a rádióadót, hogy ezzel meg tudjuk később állítani

            task.Start();
            Thread.Sleep(200);

            Console.WriteLine("megállítjuk a folyamatot");
            cts.Cancel(); //kilőjük a task-ot

            try
            {
                task.Wait(); //4. be kell várni a task végét
            }
            catch (AggregateException ex)
            {
                //5. le kell kezelni a cancelt!
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine($"Kivétel {e.Message}");
                    if (e is TaskCanceledException)
                    {
                        Console.WriteLine("Cancel történt");
                    }
                }
            }
        }

        private static void Test2()
        {
            Action todo = () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"i: {i}");
                    Thread.Sleep(100);
                }
                throw new StackOverflowException();

            };

            var task = new Task(todo);
            task.Start();

            //Ahhoz, hogy a kivételt elkapjuk, ahhoz 
            //be kell várnunk a taskot !!!

            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                //a flatten kiteríti a bonyolult kivétel fát
                Console.WriteLine(ex.Flatten().Message);

                Console.WriteLine();
                //vagy 

                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void Test1()
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
