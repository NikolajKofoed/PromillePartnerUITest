using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;


namespace PromillePartnerUITest
{
    [TestClass]
    public sealed class Test1
    {
        static string DriverDirectory = "C:\\webDrivers\\chromedriver-win64";
        static string URL = "https://testfrontend1234567890.z33.web.core.windows.net/"; // mangler rigtig URL
        static IWebDriver chromeDriver = new ChromeDriver(DriverDirectory);
        //static FirefoxOptions options = new();
        //static IWebDriver firefoxDriver = new FirefoxDriver(options);



        public IWebElement genderSelect;
        public IWebElement genderSelectMale;
        public IWebElement genderSelectFemale;

        public IWebElement ageInput;
        public IWebElement weightInput;
        public IWebElement targetPromilleInput;
        public IWebElement hoursInput;

        public IWebElement genderSelectLabel;
        public IWebElement weightInputLabel;
        public IWebElement targetPromilleInputLabel;
        public IWebElement hoursInputLabel;

        public IWebElement buttonBeregn;

        public IWebElement promilleResultDivision;
        public IWebElement resultHeader;



        [ClassInitialize]
        public static void TestClassSetUp(TestContext context)
        {
            chromeDriver.Navigate().GoToUrl(URL);

            IWebElement genderSelect = chromeDriver.FindElement(By.Id("genderSelect"));
            IWebElement genderSelectMale = chromeDriver.FindElement(By.Id("genderSelectMale"));
            IWebElement genderSelectFemale = chromeDriver.FindElement(By.Id("genderSelectFemale"));

            IWebElement ageInput = chromeDriver.FindElement(By.Id("ageInput"));
            IWebElement weightInput = chromeDriver.FindElement(By.Id("weightInput"));
            IWebElement targetPromilleInput = chromeDriver.FindElement(By.Id("targetPromilleInput"));
            IWebElement hoursInput = chromeDriver.FindElement(By.Id("hoursInput"));

            IWebElement genderSelectLabel = chromeDriver.FindElement(By.Id("genderLabel"));
            IWebElement weightInputLabel = chromeDriver.FindElement(By.Id("weightInputLabel"));
            IWebElement targetPromilleInputLabel = chromeDriver.FindElement(By.Id("targetPromilleInputLabel"));
            IWebElement hoursInputLabel = chromeDriver.FindElement(By.Id("hoursInputLabel"));

            IWebElement buttonBeregn = chromeDriver.FindElement(By.Id("buttonBeregn"));

            IWebElement promilleResultDivision = chromeDriver.FindElement(By.Id("promilleResultDivision"));
            IWebElement resultHeader = chromeDriver.FindElement(By.Id("resultHeader"));
            
            //IWebElement result = driver.FindElement(By.Id("resultText"));


            //IWebElement drukplan = driver.FindElement(By.Id("tableDrukplan"));

            
        }



        [TestMethod()]
        public void CalculateTest()
        {
            genderSelect.Click();
            genderSelectMale.Click();

            ageInput.SendKeys("20");
            weightInput.SendKeys("70");
            hoursInput.SendKeys("5");
            targetPromilleInput.SendKeys("1");

            Thread.Sleep(3000);


            IWebElement result = chromeDriver.FindElement(By.Id("resultText"));

            Assert.AreEqual("Du skal drikke ca. 1.69 genstand(e) i timen for at nå din ønskede promille. forventet alkohol drukket 101.5 gram", result.Text);
        }

        [TestMethod()]
        public void CorrectTextTest()
        {
            genderSelect.Click();

        }

        [TestMethod]
        public void GenerateDrukplanTest()
        {


            //Actions x = new Actions(chromeDriver);

            //x.keyDown(Keys.CONTROL)
            // .click(Selectable.get(0))
            // .click(Selectable.get(4))
            // .keyUp(Keys.CONTROL)
            // .build().perform();


        }





        [ClassCleanup]
        public static void TestTearDown()
        {
            chromeDriver.Quit();
        }
    }
}
