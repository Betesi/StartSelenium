using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace StartSelenium
{
    public class Tests
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


            driver.Manage().Window.Maximize(); //rahulshettyacademy.com/loginpagePractise/";

        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            //Assert.AreEqual("Login Page Practise", driver.Title); // Example assertion

            TestContext.Progress.WriteLine( driver.Title); // This will print the title of the page
            TestContext.Progress.WriteLine(driver.Url);  // This will url for the site
            TestContext.Progress.WriteLine(driver.PageSource); // This will get the html of the page
        }

        [TearDown]
        public void TearDown()
        {
            // Close the driver
            driver.Quit(); // Ensure the driver is properly closed
            driver.Close();
        }
    }
}
