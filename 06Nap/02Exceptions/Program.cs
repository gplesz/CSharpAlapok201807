using System;
using System.Runtime.CompilerServices;

namespace _02Exceptions
{
    /// <summary>
    /// végrehajtás Ctrl+F5-tel
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ///Ha saját hibakezelést szeretnénk végezni, akkor a try-catch-finally blokkot kell használnunk
            ///ebből vagy a catch vagy a finally elhagyható, de valamelyiknek lennie kell, vagy mindkettőnek.
            ///catch ágból viszont több is lehet, a szűrés alapján az az ág kapja meg
            ///a vezérlést, ahol a kivétel egyezik, vagy leszármazottja a szűrőfeltételnek
            ///ezeknek az ágaknak vagy diszjunktnak, vagy egyre bővülőnek kell lennie
            try
            { //itt történik a végrehajtás, amit futtatni akarunk azt ide tesszük
                Console.WriteLine("Main try indul");

                //ha a program folyamatában jelezni szeretnénk, hogy az alkalmazás egy adott helyzetre nincs felkészítve,
                //akkor "kivételt dobunk".

                //ezzel kivétel nélkül fut az alkalmazás
                //var helyzet = Helyzetek.Egy;

                //ezzel kivételt dob
                var helyzet = Helyzetek.Nulla;

                switch (helyzet)
                {
                    case Helyzetek.Egy:
                        Console.WriteLine($"minden ok: {helyzet}");
                        break;
                    case Helyzetek.Ketto:
                        Console.WriteLine($"minden ok: {helyzet}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"valami nem stimmel: {helyzet}");
                        break; //ez a sor sosem fog futni, mert kivételkezelésre megyünk előtte
                }

                Console.WriteLine("Main try befejeződik");
            }
            catch (ArgumentException ex)
            { //Ez az ág csak azokat a kivételeket kapja el, ami a szűrő típusból LE VAN SZÁMAZTATVA
                Console.WriteLine("Main ArgumentException catch indul");

                Console.WriteLine(ex.ToString());

                Console.WriteLine("Main ArgumentException catch befejeződik");
            }
            catch (OutOfMemoryException) { } //ilyet lehet írni, mert az előzőhöz(ekhez) képest nincs közös halmaz
            catch (InvalidOperationException) { } //ilyet lehet írni, mert az előzőhöz(ekhez) képest nincs közös halmaz
            catch (SystemException) { } //egyre bővebb halmazra szűrhetek
            catch (RuntimeWrappedException) { } //https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.runtimewrappedexception.wrappedexception?redirectedfrom=MSDN&view=netframework-4.7.2#System_Runtime_CompilerServices_RuntimeWrappedException_WrappedException
            //a 2.0-ás dotnet-ben már létezik, ez szűri a keretrendszeren kívüli hibákat
            catch (Exception ex) //KÉT funkció: 1. paraméter átvétel 2. szűrés
            { //ez az ág kapja meg a vezérlés abban az esetben, ha 
              // 1. nem kezelt kivétel töténi a try ágban 
              // ÉS 
              // 2. a létrejött kivételre igaz a beállított szűrőfeltétel 
                Console.WriteLine("Main Exception catch indul");

                Console.WriteLine(ex.ToString());

                Console.WriteLine("Main Exception catch befejeződik");
                //throw;
            }
            //catch (SystemException) { } //ez viszont értelmetlen, hiszen a korábbi szűrés (Exception) már mindent beszűrt.
            //catch { } a 2.0 előtti .NET-ek esetén ilyen szűrés kell ahhoz, hogy a keretrendszeren kívüli hibákat elkapjuk. Az a baj vele, hogy
            //ez nem csak a keretrendszeren kívüli hibákat, hanem valamennyi exception-t beszűr, viszont a 2.0-tól a RuntimeWrappedException
            //már direkt ezeket szűri, és az Exception-ből van leszármaztatva, így ennek nincs funkciója.
            //2.0 előtt az Exception szűrés után téve tudja szűrni a keretrendszeren kívüli kivételeket
            finally
            { //akármi történt előtte, ebben az ágban ami van, az biztosan elkezd végrehajtódni
                Console.WriteLine("Main finally indul");

                Console.WriteLine("Main finally befejeződik");
            }


            Console.ReadLine();
        }
    }
}
