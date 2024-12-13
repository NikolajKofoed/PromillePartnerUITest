using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PromillePartnerUITest
{
    [TestClass]
    public sealed class PromilleFront
    {
        static string DriverDirectory = "C:\\WebDrivers\\";
        static string URL = "http://127.0.0.1:5500/PromilleReading.html"; // mangler rigtig URL
        static IWebDriver chromeDriver = new ChromeDriver(DriverDirectory);
        //static FirefoxOptions options = new();
        //static IWebDriver chromeDriver = new FirefoxDriver(options);

        [ClassInitialize]
        public static void TestClassSetUp(TestContext context)
        {
            chromeDriver.Navigate().GoToUrl(URL);
        }

        [TestInitialize]
        public void TestSetUp()
        {
            chromeDriver.Navigate().GoToUrl(URL);
        }

        [ClassCleanup]
        public static void TestClassTearDown()
        {
            chromeDriver.Close();
        }

        [TestMethod]
        public void CorrectTextTest()
        {
            Thread.Sleep(1000);
            IWebElement display_latest_promillemeasurement = chromeDriver.FindElement(By.Id("display_latest_promillemeasurement"));
            Thread.Sleep(100);
            Assert.AreNotEqual(display_latest_promillemeasurement.Text, "");
            Thread.Sleep(100);
            Assert.AreNotEqual(display_latest_promillemeasurement.Text, "Promille:{{ latestPromilleReading.promille}}, time:{{latestPromilleReading.timeStampMiliseconds}}");
        }
    }
}
