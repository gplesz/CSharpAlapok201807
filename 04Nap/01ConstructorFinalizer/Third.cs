namespace _01ConstructorFinalizer
{
    public class Third : Middle
    {
        //public Third()
        //{
        //    System.Console.WriteLine("Third létrehozó: Third()");
        //}

        public Third(string name, string email) : base(name, email)
        {
            System.Console.WriteLine("Third létrehozó: Third(string name, string email)");
        }

        ~Third()
        {
            System.Console.WriteLine("véglegesítő: ~Third()");
        }
    }
}