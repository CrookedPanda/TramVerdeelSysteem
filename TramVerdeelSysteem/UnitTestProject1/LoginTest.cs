using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace DataTest
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void GetPasswordTest()
        {
            //Arrange
            string username = "test";
            ConnectionClass con = new ConnectionClass("Server=studmysql01.fhict.local;Uid=dbi405544;Database=dbi405544;Pwd=SirBotler;");
            Class1 test = new Class1(con);

            //Act
            var output = test.GetPassword(username);

            //Asserrt
            Assert.AreEqual(output, "test");
        }
    }
}
