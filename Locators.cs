using OpenQA.Selenium.Chrome;
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

namespace StartSelenium
{
    internal class Locators
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
            driver.Manage().Window.Maximize(); //rahulshettyacademy.com/loginpagePractise/";
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

        }

        [Test]
        public void LocatorIdentifier()
        {

            // These are some locators Xpath, CSS, ID, CLASSNAME, NAME, TAGNAME, LINKTEXT
            // short cut of css is #1d or .class

            driver.FindElement(By.Id("username")).SendKeys("stevensystemlimited");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("stevensystemOrganisation");
            driver.FindElement(By.Name("password")).SendKeys("1234567");
            driver.FindElement(By.XPath("//div[@class='form-group'] [5]/label/span/input")).Click(); // This xpath is used to travel from parent to child in webpage
            driver.FindElement(By.CssSelector("input[value='Sign In']")).Click(); // using CSS syntax of   Tagname[attribute ='value']



            //Thread.Sleep(3000);   // This is to wait to capture the error message because it takes about 3 seconds for the message to appear
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(By.Id("signInBtn")), "Sign In"));
            
            String errorMessage= driver.FindElement(By.ClassName("alert-danger")).Text;  // This will capture the error message and will be printed in below code
            TestContext.Progress.WriteLine(errorMessage);



             IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
             String hrefAttr = link.GetAttribute("href");
             String expectedUrl = "https://rahulshettyacademy.com/documents-request";
             Assert.AreEqual(expectedUrl, hrefAttr);













        }

        [TearDown]
        public void TearDown()
        {
            // Close the driver
            //driver.Quit(); // Ensure the driver is properly closed
        }
    }
}
