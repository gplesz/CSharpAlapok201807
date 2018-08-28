using System;

namespace _02Exceptions
{
    /// <summary>
    /// végrehajtás Ctrl+F5-tel
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Main try indul");
                FoProgram();
                Console.WriteLine("Main try végez");
            }
            catch (Exception)
            {
                Console.WriteLine("Main catch indul");
                throw;
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
            catch (Exception)
            {
                Console.WriteLine("FoProgram catch indul");
                throw;
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

                Console.WriteLine("Alprogram try végez");
            }
            catch (Exception)
            {
                Console.WriteLine("Alprogram catch indul");
                throw;
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
