using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTest
{
    [TestClass]
    public class TramTest
    {
        [TestMethod]
        public void AddTramTest()
        {
            //Arrange
            Tram tram = new Tram();

            //Act
            for (int i = 2001; i < 2073; i++)
            {
                tram.AddTram(4, 1, 1, i);
            }
            

            //Assert
        }
    }
}
