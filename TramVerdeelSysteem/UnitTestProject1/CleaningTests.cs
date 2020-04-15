using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Tests
{
    [TestClass()]
    public class CleaningTests
    {
        readonly ConnectionClass con = new ConnectionClass("Server=studmysql01.fhict.local;Uid=dbi405544;Database=dbi405544;Pwd=SirBotler;");

        [TestMethod()]
        public void AddCleaningTest()
        {
            Cleaning cleaning = new Cleaning();
            Assert.Fail();
        }
    }
}