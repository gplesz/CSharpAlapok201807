using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace _01IDisposable
{
    /// <summary>
    /// Saját maga után takarítani képes osztály készítése
    /// a beépített IDisposable felület segítségével
    /// 
    /// Mikor kell magunk után takarítani?
    /// 
    /// - külső függőség használata (file, hálózat, stb) esetén is, ha menedzselt objektumot használunk, akkor a GC megold mindent
    ///   - kivéve, ha a menedzselt kód IDisposable mintát használ, mert ekkor nekünk is kötelező ezt implementálni
    /// - nagy memóriát használunk, akkor javasolt, hogy magunk után takarítsunk.
    /// - direkt memóriakezelés/nem menedzselt memóriakezelés
    /// 
    /// </summary>
    public class ItselfCleaner : IDisposable
    {
        private bool isDisposed = false;

        //menedzselt stream, de IDisposable felületet implementál
        private Stream fileStream = new FileStream("file.txt", FileMode.Create);
        //menedzselt lista, de nagy méretű
        private List<string> managedMemory = new List<string>();
        //nem menedzselt memóriaterület
        private IntPtr unmanagedMemory = IntPtr.Zero;


        public ItselfCleaner() 
        {
            //menedzselt memória feltöltése
            for (int i = 0; i < 1000000; i++)
            {
                managedMemory.Add("AAAAAAA");
            }

            //nem menedzselt memória lefoglelása
            unmanagedMemory = Marshal.AllocHGlobal(1000000);
            //mivel nem menedzselt memóriaterületről van szó, így szólnunk
            //kell a GC-nek, hogy ezt a területet már nem használhatja
            GC.AddMemoryPressure(1000000);

        }

        /// <summary>
        /// A takarítást végző függvény
        /// 
        /// a dispose függvényben nem szabad kivételt okoznunk
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            //kivesszük a Finalizer queue-ból az osztálypéldányt,
            //hiszen takarítottunk, nincs már szükség erre
            //ezzel elérjük, hogy ha jól használjuk a using-ot, 
            //akkor a Finalizer sosem fog lefutni
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Az osztály finalizere, ha már nincs a példányra mutató hivatkozás
        /// akkor egyszer, valamikor lefut. Feladat, hogy lehetőleg sose fusson :)
        /// </summary>
        ~ItselfCleaner()
        {
            Dispose(false);
        }

        /// <summary>
        /// A "valódi" takarító függvény
        /// </summary>
        /// <param name="dispose">jelzi, hogy a Dispose függvényből hívtuk (true), vagy a Finalizerből (false). </param>
        private void Dispose(bool dispose)
        {
            if (isDisposed)
            {
                return;
            }

            //takarítás

            if (dispose)
            { //a Dispose-ból hívtuk, így a menedzselt részeket is takarítjuk

                //menedzselt IDisposable felületet használó példány felszabadítása
                //null vizsgálat, nehogy kivételre fussunk
                if (fileStream!=null)
                {
                    fileStream.Dispose();
                    fileStream = null;
                }

                //menedzselt memória felszabadítása
                //null vizsgálat, nehogy kivételre fussunk
                if (managedMemory != null)
                {
                    managedMemory.Clear();
                    managedMemory = null;
                }

            }

            //inicializálatlan helyzet kizárása, nehogy kivételre fussunk
            if (unmanagedMemory != IntPtr.Zero)
            {
                //nem menedzselt memória felszabadítása
                Marshal.FreeHGlobal(unmanagedMemory);
                //szólunk a GC-nek, hogy újra használhatja ezt a területet
                GC.RemoveMemoryPressure(1000000);
            }

            isDisposed = true;
        }
    }
}