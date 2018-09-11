using System;
using System.IO;
using System.Text;

namespace _01LocalData
{
    class Program
    {
        static void Main(string[] args)
        {
            //A Path a statikus osztály az elérési utakkal kapcsolatos dolgokban segít.

            //általában érdemes tartózkodni az abszolút elérési utaktól, helyette relatív elérési utat érdemes használni.

            //például: relatív elérési út
            var path = "EgyikKonyvtar";

            //és abszolút elérési út
            Console.WriteLine($"Ennek a relatív könyvtárnak: {path}");
            Console.WriteLine($" ez az abszolút elérési útja: {Path.GetFullPath(path)}");

            Console.WriteLine($"A temporális könyvtár: {Path.GetTempPath()}");

            var tempFile = Path.GetTempFileName();
            Console.WriteLine($"A temporális file: {tempFile}");

            Console.WriteLine($"A random file: {Path.GetRandomFileName()}");

            //ne ezt tegyük
            //"asdkfhakjsdfh.asdkfjhaksdfhk.asdklfjhaksdfhkasdfh.kajsdhfkasdhfk.txt"
            //var tempFileExt = tempFile.Split('.');
            //var ext = tempFileExt[tempFileExt.Length - 1];
            //hanem mindig használjuk a megfelelő függvényeket
            Console.WriteLine($"GetFileNameWithoutExtension: {Path.GetFileNameWithoutExtension(tempFile)}");
            Console.WriteLine($"GetExtension: {Path.GetExtension(tempFile)}");
            Console.WriteLine($"GetDirectoryName: {Path.GetDirectoryName(tempFile)}");

            var dirName = Path.Combine("egy", "ketto", "harom");

            //A könyvtárakkal kapcsolatos műveletekhez: Directory (statikus osztály)

            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }

            Console.WriteLine($"Ennek a relatív könyvtárnak: {dirName}");
            Console.WriteLine($" ez az abszolút elérési útja: {Path.GetFullPath(dirName)}");

            //Az állományokkal kapcsolatos műveleteket a File (statikus) osztály végzi.
            var fileName = "test.txt";
            File.WriteAllText(fileName, string.Format("nyilván szöveget {0} tudok írni, \n illetve speciális karaktereket: {1}, {2}, {3}, {4}, {5}"
                , "mindenképpen"
                , Environment.NewLine // az adott futtatókörnyezetnek megfelelő új sor karakterlánc
                , (char)113 //ascii kódnak megfelelő karakter
                , Convert.ToChar(115) //ugyanez máshogyan
                , '\u0027' //unikód karakter
                , new string(Encoding.ASCII.GetChars(new byte[] { 35, 36})) //byte tömbből a karakterek kódjai alapján ascii szöveget tartalmazó
                      //karakter tömböt, majd ebből szöveget tudunk gyártani
                ), 
                Encoding.UTF8); //ha akarjuk, megadhatjuk a szöveg kódolását is. Ebben esetben a visszaíráskor is meg kell adnunk, sőt, érdemes mindig megadni

            //Írásra ezek a lehetőségek, ez mindig felülírja az adott állományt
            //File.WriteAllBytes
            //File.WriteAllLines
            //File.WriteAllText

            //ezeknek az olvasó párja:

            //File.ReadAllBytes
            //File.ReadAllLines
            //File.ReadAllText

            //Meglévő állományhoz tudunk hozzáfűzni:
            //File.AppendAllLines
            //File.AppendAllText

            //A részletes File és Directory információkat:
            //a FileInfo és a DirectoryInfo szolgáltat (

            var info = new FileInfo(fileName);

            Console.WriteLine($"Ez egy könyvtár: {info.Attributes.HasFlag(FileAttributes.Directory)}");

            Console.ReadLine();
        }
    }
}
