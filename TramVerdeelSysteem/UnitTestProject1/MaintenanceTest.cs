using Data;
using Model.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTest
{
    [TestClass]
    public class MaintenanceTest
    {
        [TestMethod]
        public void AddMaintenanceTest()
        {
            //Arrange
            Maintenance maint = new Maintenance();
            MaintenanceDTO maintenanceDTO = new MaintenanceDTO();
            maintenanceDTO.TramNumber = 2001;
            maintenanceDTO.Annotation = "Cleaning i think";
            maintenanceDTO.AuthKey = "KG91WM56XkCG1zNUQkZYmA";

            //Act
            maint.AddMaintenance(maintenanceDTO);

            //Assert
        }

        [TestMethod]
        public void GetMaintenanceList()
        {

        }
    }
}
