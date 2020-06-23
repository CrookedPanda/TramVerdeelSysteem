using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace RemiseTest
{
    public class Tests
    {
        //Start instance first then test
        private IWebDriver _driver;
        public string _homeURL;
        [SetUp]
        public void Setup()
        {
            _homeURL = "https://localhost:44349/";
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        //When all tests fail, check if connected to vpn and localhost id
        private void LoadHome()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(_homeURL);
        }

        private void LoginAsUser()
        {
            _driver.FindElement(By.Id("login")).SendKeys("Groep2");
            _driver.FindElement(By.Id("password")).SendKeys("groep2");
            _driver.FindElement(By.Id("submitLogin")).Click();
        }



        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}