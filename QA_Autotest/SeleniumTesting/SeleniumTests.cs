using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace SeleniumTesting
{
    public class Tests
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new EdgeDriver(path + @"\drivers\");
        }

        [Test]
        public void verifyLogo()
        {
            driver.Navigate().GoToUrl("https://www.browserstack.com/");
            Assert.IsTrue(driver.FindElement(By.Id("logo")).Displayed);
        }

        [Test]
        public void verifyMenuItemcount()
        {
            var menuItem = driver.FindElements(By.XPath("//ul[contains(@class,'horizontal-list product-menu')]/li"));
            Assert.AreEqual(menuItem.Count, 4);
        }

        [Test]
        public void verifyPricingPage()
        {
            driver.Navigate().GoToUrl("https://browserstack.com/pricing");
            var contactUsPageHeader = driver.FindElement(By.TagName("h1"));
            Assert.IsTrue(contactUsPageHeader.Text.Contains("Replace your device lab and VMs with any of these plans"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}