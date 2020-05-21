using Data;
using Model.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTest
{
    [TestClass]
    public class RemiseTest
    {
        [TestMethod]
        public void TestGetUser()
        {
            //Arrange
            ConnectionClass con = new ConnectionClass();
            Depot depot = new Depot(con);

            //Act
            var output = depot.GetDepot("Remise Havenstraat");

            //Assert
        }
    }
}
