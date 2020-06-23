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

        [TestMethod]
        public void TestGetUser2()
        {
            //Arrange
            ConnectionClass con = new ConnectionClass();
            Track track = new Track(con);

            //Act
            var output = track.GetTrack(40);

            //Assert
        }
    }
}
