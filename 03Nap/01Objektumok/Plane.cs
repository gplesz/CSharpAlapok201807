namespace _01Objektumok
{
    public class Plane
    {
        public Plane()
        {
        }

        //Állapot: mező (field) vagy tulajdonság (property) halmaz

        //a mező nagyon hasonló a belső osztályszintű változókhoz:
        private int NrOfNodes;
        
        ///mező (field)
        ///tartalmazza az élek számát
        ///de kívülről is elérhető: írható és olvasható
        ///ez nem korlátozható
        ///használata nem javasolt
        public int NrOfEdge;
      
        //a tulajdonság (property) ugyanezt tudja, ha az alapértelmezett (default)
        //implementációt használjuk
        public int NrOfArcs { get; set; }

        //azonban a fordító egy ilyen kóddá alakítja (külön választjuk a tulajdonság írását és olvasását):

        /// <summary>
        /// backing field, ez tartalmazza a property értékét
        /// </summary>
        private int _nrOfArcs;
        /// <summary>
        /// getter függvény, visszaadja a property (backing fieldben tárolt) értékét
        /// </summary>
        /// <returns>a property értéke</returns>
        public int NrOfArcs_GET()
        { 
            return _nrOfArcs;
        }
        /// <summary>
        /// setter függvény, beállítja a property (backing fieldben tárolt) értékét
        /// </summary>
        /// <param name="value">a proerty beállítandó (új) értéke</param>
        public void NrOfArcs_SET(int value)
        {
            _nrOfArcs = value;
        }

        //Következmények:
        //1. mivel elválasztottuk az írást és az olvasást, külön tudunk a létezésükről dönteni:
        //csak olvasható property
        public int Data1 { get; } //default alak

        //csak írható property, ebben az esetben implementálnom kell, 
        //mert a bejövő adathoz nem férek máshogy hozzá
        //definíció szerint a bejövő paraméter neve "value", típusa mindig a property típusa
        private int _data2;
        public int Data2 { set { _data2 = value; } } //nem default alak: tartalmaz implementációt

        //2. külön külön tudom a láthatóságát szabályozni
        //olvasni csak az osztáűlyon belülről, írni osztályon kívülről is lehet
        public int Data3 { private get; set; } //default alak
        //olvasni mindenhonnan, írni csak osztályon belülről
        public int Data4 { get; private set; } //default alak

        //3. a fordító a default alakban egy default implementációt készít a kódunkból
        //default alak: implementáció nélküli, csak get/set szerepel a definícióban

        //4. mi van, ha szeretném implementálni a getter vagy a setter függvényt?

        //valószínüleg kell egy backing field
        private string _name;
        public string Name
        {
            get
            {
                //tetszűleges művelet 
                //majd a property típusának megfelelő érték visszaadása
                return _name;
            }
            set
            {
                //tetszőleges művelet végzése
                //felhasználhatjuk a bejövő paramétert ami a proerty típusának megfelel és "value" a neve
                _name = value;
            }
        }

        //Viselkedés: függvényeken keresztül lehet szabályozni
        //függvény overloading
        public void Show()
        {

        }

        //nem a név, hanem a szignatúra (név+paraméterek típusa) azonosítja a függvényt, így
        //ugyanolyan névvel tudunk több függvényt létrehozni, ha a szignatúrájuk különböző
        public void Show(bool disabled)
        {

        }

        //vagy
        public void Show(int posX, int posY)
        {

        }
        
        //a paraméternév nem a szignatúra része, így ez nem különbözik
        //public void Show(int X, int Y) 
        //{

        //}

        //a visszatérési érték sem a szignatúra része, így ez sem működik
        //public int Show()
        //{
        //    return 0;
        //}

        //A függvények paraméterei a következők lehetnek:
        //alapértelmezésben
        //ha a paraméter típusa értéktípusként viselkedik, akkor a paraméterátadás is érték szerint történik.
        //ha a paraméter típusa referenciatípusként viselkedik, akkor referencia szerinti átadás történik
        //ezt felül tudjuk írni, ha értéktípust szeretnénk referencia szerint átadni, akkor ref kulcsszót használunk.
        //az out paraméternél mindenképpen kell értéket adni az out-ként definiált paraméternek.
        public void Show(int height, ReferenciaTipus referencia, ref int width, out int ertek3)
        {
            //az out paraméternél mindenképpen kell értéket adni az out-ként definiált paraméternek.
            ertek3 = 10;

            System.Console.WriteLine($"Show height: {height}, referencia: {referencia.ertek}, width: {width}");

            height = height * 2;
            referencia.ertek = referencia.ertek * 2;
            //először elvégzi a műveletet két baloldali érték között
            //majd lezajlik az értékadás
            //+=, /=. -=, *=
            width *= 2;

            System.Console.WriteLine($"Show height: {height}, referencia: {referencia.ertek}, width: {width}");
        }

        //A függvények paramétereinek lehet alapértelmezett értéket adni:

        public void Show(int height=5, int width=10, string name="név")
        {

        }

    }
}