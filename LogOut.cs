using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace SauceDemo
{
    class LogOut
    {


        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var browserType = "chrome"; // or "edge"

            if (browserType == "chrome")
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
            }
            else if (browserType == "edge")
            {
                new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                driver = new EdgeDriver();
            }

            else if (browserType == "firefox")


            {
                new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                driver = new FirefoxDriver();
            }

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);  // Implicit wait good when declare globally if there is any delay it will wait for the time set but if element is found before the time set test will continue
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.saucedemo.com/v1/index.html";

        }

        [Test]

        public void LogOutFromBrowser()

        {
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user"); 
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce"); 
            driver.FindElement(By.Id("login-button")).Click();

            // Locate the dropdown element
            Thread.Sleep(5000);

            driver.FindElement(By.CssSelector("#menu_button_container > div > div:nth-child(3) > div > button")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("#logout_sidebar_link")).Click();
           



        }



        [TearDown]
        public void TearDown()
        {

            driver.Quit(); // Ensure the driver is properly closed

        }



    }


}

      
