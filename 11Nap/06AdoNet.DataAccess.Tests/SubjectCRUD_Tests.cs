using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06AdoNet.DataAccess.Tests
{
    [TestClass]
    public class SubjectCRUD_Tests
    {
        private readonly string connectionString = "Server=.\\SQLEXPRESS;Database=CodeFirstDB;Trusted_Connection=True;";

        [TestMethod]
        public void TeacherReadId1_ShouldNotNull()
        {

            //AAA: Act, Arrange, Assert: http://wiki.c2.com/?ArrangeActAssert

            //Act: előkészítés
            var dal = new DataAccessLayer(connectionString);

            //Arrange: feladat elvégzése
            var teacher = dal.TeacherRead(1);

            //Assert: eredmény ellenőrzése
            Assert.IsNotNull(teacher);
            Assert.AreEqual("Matektanár", teacher.TeacherName);
            Assert.AreEqual(1, teacher.Id);
        }

        [TestMethod]
        public void TeacherReadId0_ShouldNull()
        {

            //Act: előkészítés
            var dal = new DataAccessLayer(connectionString);

            //Arrange: feladat elvégzése
            var teacher = dal.TeacherRead(0);

            //Assert: eredmény ellenőrzése
            Assert.IsNull(teacher);
        }

    }
}
