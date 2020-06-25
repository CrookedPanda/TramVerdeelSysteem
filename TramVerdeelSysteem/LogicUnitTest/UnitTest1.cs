using NUnit.Framework;
using Logic.Interfaces;
using Logic;
using Model.DTOs;
using System.Collections.Generic;

namespace LogicUnitTest
{
    public class Tests
    {
        Logic.Depot depot;
        [SetUp]
        public void Setup()
        {
            depot = new Logic.Depot();
        }

        [Test]
        public void AddTrain()
        {
            List<int> iList = depot.GetTramList(75);
            foreach (var item in iList)
            {
                depot.AddTrain(item);
            }
        }

        [Test]
        public void Login()
        {
            
        }
    }
}