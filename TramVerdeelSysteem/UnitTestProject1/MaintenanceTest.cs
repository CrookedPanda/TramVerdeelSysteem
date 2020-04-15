using Data;
using Model.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTest
{
    [TestClass]
    public class MaintenanceTest
    {
        [TestMethod]
        public void TestDeleteAccount()
        {
            //Arrange
            Maintenance maint = new Maintenance();
            MaintenanceDTO maintenanceDTO = new MaintenanceDTO();
            maintenanceDTO.TramNumber = 2000;
            maintenanceDTO.Annotation = "Cleaning i think";
            maintenanceDTO.AuthKey = "";

            //Act
            maint.AddMaintenance(maintenanceDTO);

            //Assert
        }
    }
}
