using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Model.DTOs;


namespace Data.Tests
{
    [TestClass()]
    public class CleaningTests
    {
        readonly ConnectionClass con = new ConnectionClass("Server=studmysql01.fhict.local;Uid=dbi405544;Database=dbi405544;Pwd=SirBotler;");

        [TestMethod()]
        public void AddCleaningTest()
        {
            //Arrange
            Cleaning cleaning = new Cleaning();
            CleaningDTO cleaningDTO = new CleaningDTO();
            cleaningDTO.TramNumber = 2035;
            cleaningDTO.Annotation = "Cleaning i think";
            cleaningDTO.AuthKey = "KG91WM56XkCG1zNUQkZYmA";

            //Act
            cleaning.AddCleaning(cleaningDTO);

            //Assert
        }
    }
}