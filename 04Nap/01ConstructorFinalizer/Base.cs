namespace _01ConstructorFinalizer
{
    public class Base
    {

        /// <summary>
        /// a readonly kulcsszó azt jelenti, hogy 
        /// csak a konstruktorban változtathatjuk az értékét.
        /// </summary>
        private readonly bool IsConstructed; //= false;

        /// <summary>
        /// különleges függvény: a létrehozó (constructor)
        /// </summary>
        public Base()
        {
            System.Console.WriteLine("Base létrehozó: Base()");

            //itt olyan beállításokat tudok elvégezni, ami 
            //megoldható külső paraméterezés nélkül
            //szimuláljuk így:

            IsInitiated = true;

            IsConstructed = true;
        }

        /// <summary>
        /// Egy második konstruktor, a függyvények 
        /// overloading lehetőségét használva,
        /// ha a szignatúra különbözik, akkor 
        /// több ugyanolyan nevű függvényem is lehet
        /// </summary>
        public Base(string name) 
            : this() //ezzel meghívjuk a paraméter nélküli konstruktort, hogy el tudja végezni a beállításokat
        {
            System.Console.WriteLine("Base létrehozó: Base(string name)");
            Name = name;
        }

        public Base(string name, string email)
            : this(name) //ezzel meghívjuk az egy string paramétert váró konstruktort
        {
            System.Console.WriteLine("Base létrehozó: Base(string name, string email)");

            Email = email;
        }

        public string Name { get; private set; }

        /// <summary>
        /// Megmutatja, hogy az objektumpéldányom
        /// létrehozásakor megtörtént-e a beállítás.
        /// 
        /// a bool típus alapértelmezett értéke: false
        /// 
        /// </summary>
        public bool IsInitiated { get; private set; } //= true; //ez olyan, mintha az első konstruktorban adtam volna ki.

        /// <summary>
        /// Read-only property: csak olvasható, DE
        /// a konstruktorban írható
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Ez az osztály véglegesítő függvénye,
        /// - se láthatósági jelzése (közvetlenül nem is hívható!!!), 
        /// - se paraméterlistája
        /// - se visszaadott értéke nincs.
        /// - a keretrendszer hívja majd egyszer, valamikor
        /// </summary>
        ~Base()
        {
            System.Console.WriteLine($"véglegesítő: ~Base(), name: {Name}, Email: {Email}");
        }

    }
}