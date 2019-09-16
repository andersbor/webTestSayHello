using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
// NuGet packages must be updated to 3.141

namespace HelloAppTest
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\seleniumDrivers2";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            // _driver = new ChromeDriver(DriverDirectory); // fast
              _driver = new FirefoxDriver(DriverDirectory);  // slow
             // _driver = new EdgeDriver(DriverDirectory); // times out ... not working
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            Assert.AreEqual("Say Hello", _driver.Title);

            IWebElement inputElement = _driver.FindElement(By.Id("inputField"));
            inputElement.SendKeys("Anders");

            IWebElement buttonElement = _driver.FindElement(By.Id("button"));
            buttonElement.Click();

            IWebElement outputElement = _driver.FindElement(By.Id("outputField"));
            string text = outputElement.Text;

            Assert.AreEqual("Hello Anders", text);


        }
    }
}
