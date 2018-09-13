using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06AdoNet.DataAccess
{
    public class DataAccessLayer
    {
        private readonly string connectionString;

        public DataAccessLayer(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("Missing connectionString", nameof(connectionString));
            }

            this.connectionString = connectionString;
        }

        /// <summary>
        /// Egy tanár adatainak a betöltése
        /// </summary>
        /// <param name="id">tanár azonosítója</param>
        /// <returns>ha nincs ilyen azonosítóü, akkor null, különben a tanár adatai</returns>
        public Teacher TeacherRead(int id)
        {
            using (var con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                con.Open();
                using (var cmd = new SqlCommand())
                {
                    //Ezt a kapcsolatot használja a parancs az adatbázis azonosításához
                    cmd.Connection = con;

                    //@Id: az SQL utasítás paramétere, amit később "be lehet küldeni"
                    cmd.CommandText = "SELECT [Id],[Name] FROM [CodeFirstDB].[dbo].[Teachers] WHERE [Id] = @Id";

                    //paraméter létrehozása
                    var param = cmd.CreateParameter();
                    param.DbType = System.Data.DbType.Int32;
                    param.Direction = System.Data.ParameterDirection.Input;
                    param.ParameterName = "@Id";
                    param.Value = id;
                    
                    //a paramétert átadjuk a parancsnak
                    cmd.Parameters.Add(param);

                    //lefuttatjuk a parancsot úgy, hogy a visszakapott eredményhalmazt olvasni tudjuk
                    var reader = cmd.ExecuteReader();

                    if (!reader.Read())
                    { // nem sikerült olvasni, nincs ilyen azonosítójú rekord, visszatérünk null-lal
                        return null;
                    }

                    //beolvassuk a tanár adatait, 
                    var teacher = new Teacher()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        TeacherName = reader.GetString(reader.GetOrdinal("Name"))
                    };

                    //majd visszatérünk a tanár példánnyal
                    return teacher;
                }
            }

        }
    }
}
