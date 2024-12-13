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
    public sealed class Drukplan
    {
        static string DriverDirectory = "C:\\WebDrivers\\";
        static string URL = "http://127.0.0.1:5500/index.html"; // mangler rigtig URL
        static IWebDriver chromeDriver = new ChromeDriver(DriverDirectory);
        //static FirefoxOptions options = new();
        //static IWebDriver chromeDriver = new FirefoxDriver(options);

        [ClassInitialize]
        public static void TestClassSetUp(TestContext context)
        {
            chromeDriver.Navigate().GoToUrl(URL);

            IWebElement GetPersonalInformationInput = chromeDriver.FindElement(By.Id("getPersonalInformationInput"));

            IWebElement CurrentPromilleInput = chromeDriver.FindElement(By.Id("currentPromilleInput"));
            
            IWebElement TargetPromilleInput = chromeDriver.FindElement(By.Id("targetPromilleInput"));
            
            IWebElement HoursInput = chromeDriver.FindElement(By.Id("hoursInput"));
            
            

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
            IWebElement GetPersonalInformationInputLabel = chromeDriver.FindElement(By.Id("getPersonalInformationLabel"));
            IWebElement CurrentPromilleLabel = chromeDriver.FindElement(By.Id("currentPromilleLabel"));
            IWebElement TargetPromilleInputLabel = chromeDriver.FindElement(By.Id("targetPromilleLabel"));
            IWebElement HoursLabel = chromeDriver.FindElement(By.Id("hoursLabel"));
            IWebElement SelectDrinksLabel = chromeDriver.FindElement(By.Id("selectDrinksLabel"));

            Assert.AreEqual(GetPersonalInformationInputLabel.Text, "Id for dine personlige informationer:");
            Assert.AreEqual(CurrentPromilleLabel.Text, "Nuværende promille:");
            Assert.AreEqual(TargetPromilleInputLabel.Text, "Ønsket promille:");
            Assert.AreEqual(HoursLabel.Text, "Længde af drukplan:");
            Assert.AreEqual(SelectDrinksLabel.Text, "Vælg drinks fra listen:");
        }

        [TestMethod]
        public void CorrectInputTest()
        {
            IWebElement GetPersonalInformationInputLabel = chromeDriver.FindElement(By.Id("getPersonalInformationLabel"));
            IWebElement CurrentPromilleLabel = chromeDriver.FindElement(By.Id("currentPromilleLabel"));
            IWebElement TargetPromilleInputLabel = chromeDriver.FindElement(By.Id("targetPromilleLabel"));
            IWebElement HoursLabel = chromeDriver.FindElement(By.Id("hoursLabel"));
            IWebElement SelectDrinksLabel = chromeDriver.FindElement(By.Id("selectDrinksLabel"));

            //Assert.AreEqual(GetPersonalInformationInput.GetAttribute("type"), "text");
            //Assert.AreEqual(CurrentPromilleInput.GetAttribute("type"), "number");
            //Assert.AreEqual(TargetPromilleInput.GetAttribute("type"), "number");
            //Assert.AreEqual(HoursInput.GetAttribute("type"), "number");
            //Assert.AreEqual(SelectDrinksInput.GetAttribute("type"), "text");
        }

        [TestMethod]
        public void CorrectButtonTest()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            
            IWebElement SelectDrinksInput = chromeDriver.FindElement(By.Id("selectDrinksInput"));

            ((IJavaScriptExecutor)chromeDriver).ExecuteScript("arguments[0].scrollIntoView(true);", SelectDrinksInput);
            Actions action = new(chromeDriver);
            action.MoveToElement(SelectDrinksInput).Click(SelectDrinksInput).Build().Perform();

            IWebElement DrinksModal = chromeDriver.FindElement(By.Id("drinksModal"));

            IEnumerable<IWebElement> Drinks = DrinksModal.FindElements(By.ClassName("form-check"));
            Assert.AreEqual(Drinks.Count(), 25);

            //Thread.Sleep(10000);
            //SelectDrinksInput.Click();



        }

        private static void OurClearMethod(IWebElement element)
        {
            ((IJavaScriptExecutor)chromeDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Actions action = new(chromeDriver);
            action.MoveToElement(element).Click(element).Build().Perform();
            element.Clear();
            //string inputText = element.Text;
            //if (inputText != null)
            //{
            //    for (int i = 0; i < inputText.Length; i++)
            //    {
            //        element.SendKeys(Keys.Backspace);
            //    }
            //}
        }

        [TestMethod]
        public void GenerateDrukplanTest()
        {
            IWebElement GetPersonalInformationInput = chromeDriver.FindElement(By.Id("getPersonalInformationInput"));
            IWebElement CurrentPromilleInput = chromeDriver.FindElement(By.Id("currentPromilleInput"));
            IWebElement TargetPromilleInput = chromeDriver.FindElement(By.Id("targetPromilleInput"));
            IWebElement HoursInput = chromeDriver.FindElement(By.Id("hoursInput"));
            IWebElement SelectDrinksInput = chromeDriver.FindElement(By.Id("selectDrinksInput"));
            IWebElement GenerateDrukplanButton = chromeDriver.FindElement(By.Id("saveSettingsButton"));

            //THIS DOES NOT WORK

            //GetPersonalInformationInput.Clear();
            OurClearMethod(GetPersonalInformationInput);
            Thread.Sleep(300);
           
            GetPersonalInformationInput.SendKeys("2");

            OurClearMethod(CurrentPromilleInput);
            Thread.Sleep(300);
            CurrentPromilleInput.SendKeys("0");

            OurClearMethod(TargetPromilleInput);
            Thread.Sleep(300);
            TargetPromilleInput.SendKeys("1");

            OurClearMethod(HoursInput);
            Thread.Sleep(300);
            HoursInput.SendKeys("5");




            ((IJavaScriptExecutor)chromeDriver).ExecuteScript("arguments[0].scrollIntoView(true);", SelectDrinksInput);
            Actions action = new(chromeDriver);
            action.MoveToElement(SelectDrinksInput).Click(SelectDrinksInput).Build().Perform();

            IWebElement DrinksModal = chromeDriver.FindElement(By.Id("drinksModal"));

            IEnumerable<IWebElement> Drinks = DrinksModal.FindElements(By.ClassName("form-check"));
            Assert.AreEqual(Drinks.Count(), 25);

            for(int i = 1; i < 5; i++)
            {
                Thread.Sleep(500);
                IWebElement Drink = DrinksModal.FindElement(By.Id($"drink-{i}"));
                Drink.Click();
            }

            Thread.Sleep(3000);
            IWebElement CloseDrinksModalButton = DrinksModal.FindElement(By.Id("closeDrinksModalButton"));
            //CloseDrinksModalButton.Click();
            Assert.IsTrue(CloseDrinksModalButton.Displayed, "The close button is not visible!");
            CloseDrinksModalButton.Click();

            //action.MoveToElement(CloseDrinksModalButton).Click(CloseDrinksModalButton).Build().Perform();

            //Thread.Sleep(10000);
            //SelectDrinksInput.Click();

            Thread.Sleep(3000);
            ((IJavaScriptExecutor)chromeDriver).ExecuteScript("arguments[0].scrollIntoView(true);", GenerateDrukplanButton);

            Assert.IsTrue(GenerateDrukplanButton.Displayed, "The close button is not visible!");
            action = new(chromeDriver);
            action.MoveToElement(GenerateDrukplanButton).Click(GenerateDrukplanButton).Build().Perform();
            // GenerateDrukplanButton.Click();

            Thread.Sleep(1000);
            IWebElement DrukplanTable = chromeDriver.FindElement(By.Id("drukplanTable"));
            ((IJavaScriptExecutor)chromeDriver).ExecuteScript("arguments[0].scrollIntoView(true);", DrukplanTable);
            Thread.Sleep(1000);
            //IEnumerable<IWebElement> Rows = DrukplanTable.FindElements(By.TagName("tr"));
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            IEnumerable<IWebElement> Rows = wait.Until(DrukplanTable =>  DrukplanTable.FindElements(By.TagName("tr")));
            Assert.AreEqual(10, Rows.Count()); //inklusiv header
        }

        [TestMethod]
        public void GenerateDrukplanAndStartSessionTest()
        {
            IWebElement GetPersonalInformationInput = chromeDriver.FindElement(By.Id("getPersonalInformationInput"));
            IWebElement CurrentPromilleInput = chromeDriver.FindElement(By.Id("currentPromilleInput"));
            IWebElement TargetPromilleInput = chromeDriver.FindElement(By.Id("targetPromilleInput"));
            IWebElement HoursInput = chromeDriver.FindElement(By.Id("hoursInput"));
            IWebElement SelectDrinksInput = chromeDriver.FindElement(By.Id("selectDrinksInput"));
            IWebElement GenerateDrukplanButton = chromeDriver.FindElement(By.Id("saveSettingsButton"));

            //THIS DOES NOT WORK
            OurClearMethod(GetPersonalInformationInput);
            Thread.Sleep(300);

            GetPersonalInformationInput.SendKeys("2");

            OurClearMethod(CurrentPromilleInput);
            Thread.Sleep(300);
            CurrentPromilleInput.SendKeys("0");

            OurClearMethod(TargetPromilleInput);
            Thread.Sleep(300);
            TargetPromilleInput.SendKeys("1");

            OurClearMethod(HoursInput);
            Thread.Sleep(300);
            HoursInput.SendKeys("5");


            ((IJavaScriptExecutor)chromeDriver).ExecuteScript("arguments[0].scrollIntoView(true);", SelectDrinksInput);
            Actions action = new(chromeDriver);
            action.MoveToElement(SelectDrinksInput).Click(SelectDrinksInput).Build().Perform();

            IWebElement DrinksModal = chromeDriver.FindElement(By.Id("drinksModal"));

            IEnumerable<IWebElement> Drinks = DrinksModal.FindElements(By.ClassName("form-check"));
            Assert.AreEqual(Drinks.Count(), 25);

            for (int i = 1; i < 5; i++)
            {
                Thread.Sleep(500);
                IWebElement Drink = DrinksModal.FindElement(By.Id($"drink-{i}"));
                Drink.Click();
            }

            Thread.Sleep(3000);
            IWebElement CloseDrinksModalButton = DrinksModal.FindElement(By.Id("closeDrinksModalButton"));
            //CloseDrinksModalButton.Click();
            Assert.IsTrue(CloseDrinksModalButton.Displayed, "The close button is not visible!");
            CloseDrinksModalButton.Click();

            //action.MoveToElement(CloseDrinksModalButton).Click(CloseDrinksModalButton).Build().Perform();

            //Thread.Sleep(10000);
            //SelectDrinksInput.Click();

            Thread.Sleep(3000);
            ((IJavaScriptExecutor)chromeDriver).ExecuteScript("arguments[0].scrollIntoView(true);", GenerateDrukplanButton);

            Assert.IsTrue(GenerateDrukplanButton.Displayed, "The close button is not visible!");
            action = new(chromeDriver);
            action.MoveToElement(GenerateDrukplanButton).Click(GenerateDrukplanButton).Build().Perform();
            // GenerateDrukplanButton.Click();

            Thread.Sleep(1000);
            IWebElement DrukplanTable = chromeDriver.FindElement(By.Id("drukplanTable"));
            ((IJavaScriptExecutor)chromeDriver).ExecuteScript("arguments[0].scrollIntoView(true);", DrukplanTable);
            Thread.Sleep(1000);
            //IEnumerable<IWebElement> Rows = DrukplanTable.FindElements(By.TagName("tr"));
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            IEnumerable<IWebElement> Rows = wait.Until(DrukplanTable => DrukplanTable.FindElements(By.TagName("tr")));
            Assert.AreEqual(10, Rows.Count()); //inklusiv header



            IWebElement StartSessionButton = chromeDriver.FindElement(By.Id("startSessionButton"));
            ((IJavaScriptExecutor)chromeDriver).ExecuteScript("arguments[0].scrollIntoView(true);", StartSessionButton);
            Assert.AreEqual("Start Timer", StartSessionButton.Text);
            action.MoveToElement(StartSessionButton).Click(StartSessionButton).Build().Perform();

            IWebElement CurrentSessionTime = chromeDriver.FindElement(By.Id("currentSessionTime"));
            Assert.AreEqual(CurrentSessionTime.Text, "00:00:00");
        }
    }
}
