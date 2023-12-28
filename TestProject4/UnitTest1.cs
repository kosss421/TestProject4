using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

using System;

namespace TestProject4
{
    public class Tests
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void login()
        {
            driver.Navigate().GoToUrl("https://guest:welcome2qauto@qauto2.forstudy.space/");
            driver.Manage().Window.Size = new System.Drawing.Size(1090, 774);
            driver.FindElement(By.CssSelector(".btn-outline-white")).Click();
            {
                var element = driver.FindElement(By.CssSelector(".btn-outline-white"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            {
                var element = driver.FindElement(By.TagName("body"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            driver.FindElement(By.Id("signinEmail")).SendKeys("auto421@gmail.com");
            driver.FindElement(By.Id("signinPassword")).SendKeys("Auto2023");
            driver.FindElement(By.CssSelector(".btn-primary:nth-child(2)")).Click();
            {
                var element = driver.FindElement(By.CssSelector(".btn-link:nth-child(2)"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            {
                WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(2));
                wait.Until(driver => driver.FindElements(By.XPath("//a[@class=\"btn btn-link text-danger btn-sidebar sidebar_btn\"]")).Count > 0);
            }
            var elements = driver.FindElements(By.XPath("//a[@class=\"btn btn-link text-danger btn-sidebar sidebar_btn\"]"));
            Assert.True(elements.Count > 0);
            driver.FindElement(By.XPath("//a[@class=\"btn btn-link text-danger btn-sidebar sidebar_btn\"]")).Click();
        }
    }
}