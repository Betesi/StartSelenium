using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SauceDemo
{
    public class ValidLogin
    {
         IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var browserType = "firefox"; // or "edge"

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


            driver.Manage().Window.Maximize();

            driver.Url = "https://www.saucedemo.com/v1/index.html";

        }

        [Test]
        public void ValidStandardUser()
        {

            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();


            



        }
        [Test]
        public void ValidLockedOutUser()
        {

            driver.FindElement(By.Id("user-name")).SendKeys("locked_out_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();







        }

        [Test]
        public void ValidProblemUser()
        {

            driver.FindElement(By.Id("user-name")).SendKeys("problem_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();






        }

        [Test]
        public void ValidPerformanceGlitchUser()
        {

            driver.FindElement(By.Id("user-name")).SendKeys("performance_glitch_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();






        

        }

        [TearDown]
        public void TearDown()
        {
            // Close the driver
           
            driver.Close();
        }
    }
}
