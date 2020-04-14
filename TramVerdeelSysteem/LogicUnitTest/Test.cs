using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Logic;
using Model;
using Model.ViewModels;

namespace LogicUnitTest
{
    public class Test
    {
        Authentication auth = new Authentication();

        [SetUp]
        public void Setup()
        {

        }

        //[Test]
        //public void AddAccount() 
        //{
        //    List<int> roles = new List<int>();
        //    auth.AddAccount("Groep2", "groep2", roles);
        //}

         [Test]
        public void Login() 
        {
            AuthView view = new AuthView();
            view = auth.Login("Groep2", "groep2");
            Assert.AreEqual("Groep2", view.Name);
        }
    }
}
