using Data;
using Model.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTest
{
    public class MaintenanceTest
    {
        [TestMethod]
        public void TestDeleteAccount()
        {
            //Arrange
            Maintenance maint = new Maintenance();
            MaintenanceDTO maintenanceDTO = new MaintenanceDTO();
            maintenanceDTO.Target = 2000;
            maintenanceDTO.Annotation = "Cleaning i think";
            maintenanceDTO.AuthKey = "";

            //Act
            maint.AddMaintenance(maintenanceDTO);

            //Assert
        }
    }
}
