using System;
using System.Collections.Generic;
using System.Data;
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

        public int TeacherDelete(int id)
        {
            using (var con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                con.Open();
                using (var cmd = new SqlCommand())
                {
                    //Ezt a kapcsolatot használja a parancs az adatbázis azonosításához
                    cmd.Connection = con;

                    //@Id a beküldhető paraméter
                    cmd.CommandText = "DELETE FROM [dbo].[Teachers] WHERE [Id] = @Id";

                    cmd.Parameters
                       .Add("@Id", System.Data.SqlDbType.Int)
                       .Value = id;

                    //Úgy futtatunk, hogy nem olvasunk eredményhalmazt
                    var affectedRows = cmd.ExecuteNonQuery();

                    return affectedRows;
                }
            }
        }

        public int TeacherCreate(Teacher teacher)
        {
            using (var con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                con.Open();
                using (var cmd = new SqlCommand())
                {
                    //Ezt a kapcsolatot használja a parancs az adatbázis azonosításához
                    cmd.Connection = con;
                    //@Name kívülről kitöltendő paraméter
                    //Két parancsot futtatunk, a második visszaadja a beszúrt rekord azonosítóját
                    cmd.CommandText = "INSERT INTO [dbo].[Teachers] ([Name]) VALUES (@Name);SELECT SCOPE_IDENTITY() as ID";

                    cmd.Parameters
                       .Add("@Name", System.Data.SqlDbType.NVarChar, -1)
                       .Value = teacher.TeacherName;

                    //lefuttatjuk a parancsot úgy, hogy a visszakapott eredményhalmazt olvasni tudjuk
                    var reader = cmd.ExecuteReader();

                    if (!reader.Read())
                    { // nem sikerült olvasni, nem sikerült a beszúrás. 0-val térünk vissza
                        return 0;
                    }

                    //A második lekérdezés 1 oszlopos, így a 0-s indexű oszlopra van szükségünk
                    //a SCOPE_IDENTITY() numeric(18,0) értékkel tér vissza, ami "nem fér bele" az int32-be 
                    //így betöltjük decimálisként
                    var id = (int)reader.GetDecimal(0);

                    return id;

                }
            }
        }

        public List<Teacher> TeacherList()
        {
            var dataSet = new System.Data.DataSet();

            using (var con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                con.Open();
                using (var cmd = new SqlCommand())
                {
                    //Ezt a kapcsolatot használja a parancs az adatbázis azonosításához
                    cmd.Connection = con;

                    //Nincs beküldhető paraméter
                    cmd.CommandText = "SELECT [Id],[Name] FROM [dbo].[Teachers]";

                    //A DataAdapter segítségével a táblázatokat betölthetem DataSet példányokba
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dataSet, "Teachers");
                    }
                }
            }

            //A továbbiakban a dataSet-ből tudok dolgozni
            var teachers = new List<Teacher>();
            foreach (System.Data.DataRow row in dataSet.Tables["Teachers"].Rows)
            { //végigmegyünk a sorokon
                var teacher = new Teacher()
                {
                    Id = row.Field<int>("Id"),
                    TeacherName = row.Field<string>("Name")
                };

                teachers.Add(teacher);
            }

            return teachers;

        }

        public int TeacherUpdate(Teacher teacher)
        {
            using (var con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                con.Open();
                using (var cmd = new SqlCommand())
                {
                    //Ezt a kapcsolatot használja a parancs az adatbázis azonosításához
                    cmd.Connection = con;

                    //@Id és a @Name a beküldhető paraméterek
                    cmd.CommandText = "UPDATE [dbo].[Teachers] SET [Name] = @Name WHERE [Id] = @Id";

                    cmd.Parameters
                       .Add("@Id", System.Data.SqlDbType.Int)
                       .Value = teacher.Id;

                    cmd.Parameters
                       .Add("@Name", System.Data.SqlDbType.NVarChar, -1)
                       .Value = teacher.TeacherName;

                    //Úgy futtatunk, hogy nem olvasunk eredményhalmazt
                    var affectedRows = cmd.ExecuteNonQuery();

                    return affectedRows;
                }
            }
        }
    }
}
