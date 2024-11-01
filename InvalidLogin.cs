﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo
{
    internal class InvalidLogin
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
        public void InvalidStandardUserName()
        {

            driver.FindElement(By.Id("user-name")).SendKeys("standard_userG");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();


        }

        [Test]
        public void InvalidValidStandardPassword()

        {


            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauceR");
            driver.FindElement(By.Id("login-button")).Click();


        }

        [Test]
        public void InvalidLockedOutUserName()

        {


         


            driver.FindElement(By.Id("user-name")).SendKeys("locked_out_userr");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();


        }
        [Test]

        public void InvalidLockedOutPassword()

       

            {


                
             


                driver.FindElement(By.Id("user-name")).SendKeys("locked_out_user");
                driver.FindElement(By.Id("password")).SendKeys("secret_sauce#");
                driver.FindElement(By.Id("login-button")).Click();


            }

        [Test]


        public void InvalidProblemUsername()



        {


         


            driver.FindElement(By.Id("user-name")).SendKeys("problem_user£$%");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();


        }

        [Test]


        public void InvalidProblemUserPassword()



        {


          


            driver.FindElement(By.Id("user-name")).SendKeys("problem_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce$%&");
            driver.FindElement(By.Id("login-button")).Click();


        }


        [Test]


        public void InvalidPerformanceGlitchUsername()



        {


         


            driver.FindElement(By.Id("user-name")).SendKeys(" performance_glitch_userrr");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();


        }


        [Test]


        public void InvalidPerformanceGlitchPassword()



        {


         


            driver.FindElement(By.Id("user-name")).SendKeys(" performance_glitch_user");
            driver.FindElement(By.Id("password")).SendKeys("");
            driver.FindElement(By.Id("login-button")).Click();


        }













        











        [TearDown]
        public void TearDown()
        {
            //Close the driver

            driver.Quit(); 
        }
    }
}
