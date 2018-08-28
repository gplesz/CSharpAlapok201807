using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03ExceptionDotNetFramework
{
    /// <summary>
    /// végrehajtás Ctrl+F5-tel
    /// </summary>
    class Program
    {
        /// <summary>
        /// Az egymásba ágyazott hibakezelési struktúra függvényhívások nélkül is lehetséges
        /// ugyanígy működik, ha direktben a Main kódba írtuk volna a három blokkot - egymásba ágyazva
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Main try indul");
                FoProgram();
                Console.WriteLine("Main try végez");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Main catch indul");
                Console.WriteLine($"Main: {ex.ToString()}");
                //throw;
                //5. megközelítés
                throw new ApplicationException("Main saját kivétel", ex);
                Console.WriteLine("Main catch végez");
            }
            finally
            {
                Console.WriteLine("Main finally indul");
                Console.WriteLine("Main finally végez");
            }
        }

        private static void FoProgram()
        {
            try
            {
                Console.WriteLine("FoProgram try indul");
                Alprogram();
                Console.WriteLine("FoProgram try végez");
            }
            catch (Exception ex)
            {
                Console.WriteLine("FoProgram catch indul");
                Console.WriteLine($"FoProgram: {ex.ToString()}");
                //throw;
                //5. megközelítés
                throw new ApplicationException("Főprogram saját kivétel", ex);
                Console.WriteLine("FoProgram catch végez");
            }
            finally
            {
                Console.WriteLine("FoProgram finally indul");
                Console.WriteLine("FoProgram finally végez");
            }
        }

        private static void Alprogram()
        {
            try
            {
                Console.WriteLine("Alprogram try indul");
                throw new Exception("EUR utalást kéne végezni, de a megadott számla HUF!");
                Console.WriteLine("Alprogram try végez");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Alprogram catch indul");
                Console.WriteLine($"Alprogram: {ex.ToString()}");
                //kivételkezelési megközelítések:
                //1. elnyeljük a hibát, nincs throw-t
                //2. "rethrow" továbbdobjuk a kivétel eggyel
                //throw;
                //3. továbbdobjuk a kapott kivételt
                //throw ex;
                //4. saját kivételt dobunk
                //throw new ApplicationException("Saját kivétel");
                //5. saját kivételt dobunk, de becsomagoljuk a kapott kivételt
                throw new ApplicationException("Alprogram saját kivétel", ex);

                Console.WriteLine("Alprogram catch végez");
            }
            finally
            {
                Console.WriteLine("Alprogram finally indul");
                Console.WriteLine("Alprogram finally végez");
            }
        }
    }
}
