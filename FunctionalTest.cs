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
    internal class FunctionalTest


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

        public void DropDown()

        {

         IWebElement dropDown =   driver.FindElement(By.CssSelector("select.form-control"));

            SelectElement s = new SelectElement(dropDown);  // select class is used to play with dropdown, pass the dropdowm to know where to target
            s.SelectByText("Teacher");    // by test in the dropdown

            s.SelectByValue("consult");  // you can select based on the value as well in the element

            s.SelectByIndex(0);    // selecting by index also


          IList <IWebElement>  rdos =  driver.FindElements(By.CssSelector("input[type='radio']"));   // two elememts and you can select by index

            foreach (IWebElement radioButton in rdos)
            {

                if (radioButton.GetAttribute("value").Equals("user"))
                {
                    radioButton.Click();
                }

               // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
               // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));


                //Thread.Sleep(8000);

                //driver.FindElement(By.ClassName("btn-success")).Click();
                //driver.FindElement(By.Id("okayBtn")).Click();
                //driver.FindElement(By.Id("okayBtn")).Click();
                //Boolean result = driver.FindElement(By.Id("usertype")).Selected;
                //Assert.That(result, Is.True);

            }
        }







    }
}
