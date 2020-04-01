using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System;

namespace DataTest
{
    [TestClass]
    public class LoginTest
    {
        readonly ConnectionClass con = new ConnectionClass("Server=studmysql01.fhict.local;Uid=dbi405544;Database=dbi405544;Pwd=SirBotler;");

        [TestMethod]
        public void TestGetUser()
        {
            //Arrange
            string username = "test";
            
            Authorisation test = new Authorisation(con);

            //Act
            var output = test.GetUser(username);

            //Assert
            Assert.AreEqual(output, "test");
        }

        [TestMethod]
        public void TestInsertQuery()
        {
            //Arrange
            Authorisation test = new Authorisation(con);

            //Act
            test.AuthorisePerson(1, 1, DateTime.Now);

            //Assert
        }

        [TestMethod]
        public void TestDeleteQuery()
        {
            //Arrange
            Authorisation test = new Authorisation(con);

            //Act
            test.DeauthorisePerson(1);

            //Assert
        }
    }
}
