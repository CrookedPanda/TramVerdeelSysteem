//using NUnit.Framework;
//using Logic.Interfaces;
//using Logic;
//using Model.DTOs;

//namespace LogicUnitTest
//{
//    public class Tests
//    {
//        static DBcontext context = new DBcontext();
//        Authentication auth = new Authentication(context);

//        [SetUp]
//        public void Setup()
//        {

//        }

//       //[Test]
//        public void AddAccount()
//        {

//            auth.AddAccount("Test", "test123", 1);
//            AccountDTO result = context.accounts.Find(x => x.Username == "Test");
//            Assert.AreEqual(result.Username, "Test");
//        }

//       // [Test]
//        public void Login()
//        {
//            auth.Login("Test", "test123");
//            LoginStampDTO result = context.loginstamps.Find(x => x.username == "Test");

//            Assert.AreEqual(result.username, "Test");
//            Assert.Pass();
//        }
//    }
//}