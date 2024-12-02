using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace PromillePartnerUITest
{
    [TestClass]
    public sealed class Test1
    {
        static string DriverDirectory = "C:\\webDrivers\\chromedriver-win64";
        static string URL = "https://hbhhjhjghj-cce9dnhecuhvd4dq.canadacentral-01.azurewebsites.net/"; // mangler rigtig URL
        static IWebDriver driver = new ChromeDriver(DriverDirectory);


        
        [ClassInitialize]
        public static void TestClassSetUp(TestContext context)
        {
            driver.Navigate().GoToUrl(URL);


        }



        [TestMethod]
        public void TestMethod1()
        {
        }


        [ClassCleanup]
        public static void TestTearDown()
        {
            driver.Quit();
        }
    }
}
