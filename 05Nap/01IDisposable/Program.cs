using System;

namespace _01IDisposable
{
    class Program
    {
        static void Main(string[] args)
        {
            ////készítünk egy önmaga után rendet hagyó/maga után eltakarító osztályt
            //var takarito = new ItselfCleaner();

            //try //megpróbálja a kódblokkot végrehajtani
            //{
            //    //elvégezzük a dolgunkat
            //}
            //finally //miután az előzőek lefutottak, akár hiba van akár nem, ez a kódblokk mindenképpen lefut
            //{
            //    //az IDisposable felület dispose függvényét használjuk
            //    ((IDisposable)takarito).Dispose();
            //}


            //hogy ne kelljen mindig ezt a sok kódot leírni, ezért 
            //ilyen 'syntactic sugar' használatával a fordító generálja nekünk ugyanezt
            using (var takarito = new ItselfCleaner())
            { //ebben a kódblokkban van a védendő használat

            }


        }
    }
}
