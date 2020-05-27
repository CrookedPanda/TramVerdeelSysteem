using Data;
using Model.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DataTest
{
    [TestClass]
    public class MaintenanceTest
    {
        [TestMethod]
        public void AddMaintenanceTest()
        {
            //Arrange
            //Maintenance maint = new Maintenance();
            //MaintenanceDTO maintenanceDTO = new MaintenanceDTO();
            //maintenanceDTO.TramNumber = 2001;
            //maintenanceDTO.Annotation = "Cleaning i think";
            //maintenanceDTO.AuthKey = "KG91WM56XkCG1zNUQkZYmA";

            //Act
            //maint.AddMaintenance(maintenanceDTO);

            //Assert
        }

        [TestMethod]
        public void GetMaintenanceList()
        {

        }

        [TestMethod]
        public void GetMaintenanceHistory()
        {
            //arrange
            Maintenance maintenance = new Maintenance();
            //act
            List<MaintenanceHistoryDTO> maintenanceHistoryDTOList = new List<MaintenanceHistoryDTO>();
            maintenanceHistoryDTOList = maintenance.GetServiceHistory();
            //assert
        }

        [TestMethod]
        public void GetCleaningHistory()
        {
            //arrange
            Maintenance maintenance = new Maintenance();
            //act
            List<CleaningHistoryDTO> cleaningHistoryDTOList = new List<CleaningHistoryDTO>();
            cleaningHistoryDTOList = maintenance.GetCleaningHistory();
            //assert
        }
    }
}
