using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace Tests
{
    public class Tests
    {
        [TestFixture]
        public class WebTest
        {
            IWebDriver driver;

            public void WaitForElement() //prevent driver timeout
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }

            [SetUp]
            public void GlobalSetup()
            {
                try
                {
                    driver = new ChromeDriver();
                    WaitForElement();
                    driver.Navigate().GoToUrl("https://oxccc-information-system.firebaseapp.com");
                    driver.Manage().Window.Maximize();
                    Assert.AreEqual("oxccc-information-system", driver.Title);
                    Console.WriteLine(driver.Title);
                }
                catch (Exception loginException)
                {
                    Console.WriteLine(loginException);
                }
            }

            [TestCase(TestName = "Account Registation")]
            [Test, Order(1)]
            public void Test1()
            {
                Assert.AreEqual("OXCCC Information System", driver.FindElement(By.XPath("/html/body/div/div/main/div/div/div/h1")).Text);
                driver.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div/div[2]/div/form/div[3]/a[1]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div/form/div[1]/div/div[1]/div/input")).SendKeys("Test"); //First name
                WaitForElement();
                driver.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div/form/div[2]/div/div[1]/div/input")).SendKeys("User"); //Last name
                driver.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div/form/div[3]/div/div[1]/div/input")).SendKeys("testUser2@gmail.com"); //Enter fake E-mail
                driver.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div/form/div[4]/div/div[1]/div[1]/input")).SendKeys("111111"); //Password
                driver.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div/form/div[5]/div/div[1]/div[1]/input")).SendKeys("111111"); //confirm passowrd
                WaitForElement(); //wait for register button to activate
                driver.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div/form/div[6]/button")).Click();
                Assert.AreEqual("Daily Bible Verse", driver.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div/div[1]/div/div[1]/h4")).Text); //Confirm redirect to login 
            }

            [TestCase(TestName = "Login")]
            [Test, Order(2)]
            public void Test2()
            {
                Assert.AreEqual("OXCCC Information System", driver.FindElement(By.XPath("/html/body/div/div/main/div/div/div/h1")).Text);
                driver.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div/div[2]/div/form/div[1]/div[2]/div[1]/div/input")).SendKeys("testUser@gmail.com"); //Enter E-mail
                driver.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div/div[2]/div/form/div[2]/div[2]/div[1]/div[1]/input")).SendKeys("111111"); //Enter password 
                WaitForElement(); //wait for login button to activate 
                driver.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div/div[2]/div/form/button")).Click();
                Assert.AreEqual("DASHBOARD", driver.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div[1]/header/div[2]/div/div/div[2]/div/a[1]")).Text); //confirm redirect to Dashboard page
                Thread.Sleep(10000);
            }

            [TearDown]
            public void TearDown()
            {
                driver.Quit(); //quit the Chromdriver 
            }
        }
    }
}