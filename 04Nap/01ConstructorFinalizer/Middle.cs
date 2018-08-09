namespace _01ConstructorFinalizer
{
    public class Middle : Base 
    {
        //ha nincs konstruktor implementálva egy osztályban, akkor
        //a fordító önszorgalomból létrehoz egy paraméter nélküli (un. default) konstruktort
        //egy ilyet:
        //public Middle() { }

        //ami egész addig így van, amíg nem implementálunk saját, paraméteres konstruktort.


        //public Middle()
        //{
        //    System.Console.WriteLine("Middle létrehozó: Middle()");
        //}

        public Middle(string name, string email)
            : base(name, email) //mivel csak egy ősosztályunk van, ez az ősosztály megfelelő szignatúrájú konstruktorát hívja
        {
            System.Console.WriteLine("Middle létrehozó: Middle(string name, string email)");
        }

        ~Middle()
        {
            System.Console.WriteLine("véglegesítő: ~Middle()");
        }
    }
}