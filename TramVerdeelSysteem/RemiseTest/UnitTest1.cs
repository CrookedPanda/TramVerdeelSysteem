using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using System.Threading;

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
            _homeURL = "https://localhost:44360/";
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

        private void ProceedError()
        {
            //only should be added when certificate error
            _driver.FindElement(By.Id("details-button")).Click();
            _driver.FindElement(By.Id("proceed-link")).Click();
        }

        private void ClickSector(int trackNumber, int sectorPosition)
        {
            Thread.Sleep(1000);
            string id = trackNumber.ToString() + "/" + sectorPosition.ToString();
            _driver.FindElement(By.Name(id)).Click();
        }

        private void AddTrain(int tramNumber)
        {
            Thread.Sleep(1000);
            string id = tramNumber.ToString();
            _driver.FindElement(By.Id("tramId")).SendKeys(id);
            _driver.FindElement(By.Id("sectorAccept")).Click();
        }

        [Test]
        public void Test1()
        {
            LoadHome();
            ProceedError();
            LoginAsUser();
            ClickSector(34, 1);
            AddTrain(2018);
        }

        [Test]
        public void Test2()
        {
            LoadHome();
            ProceedError();
            LoginAsUser();
            _driver.Navigate().GoToUrl(_homeURL + "Conductor/Index");
            _driver.FindElement(By.Id("2")).Click();
            _driver.FindElement(By.Id("0")).Click();
            _driver.FindElement(By.Id("1")).Click();
            _driver.FindElement(By.Id("8")).Click();
            _driver.FindElement(By.Name("Maintenance")).Click();
            _driver.FindElement(By.Id("submitTask")).Click();
        }
    }
}