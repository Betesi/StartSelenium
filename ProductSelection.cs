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

namespace SauceDemo
{
    internal class ProductSelection
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

        public void StandardUserProductSelection   () {

            string[] expectedProducts = { "Sauce Labs Backpack", "Sauce Labs Bike Light" };
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();


           
            //{

            driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(1) > div.pricebar > button")).Click();
            driver.FindElement(By.CssSelector("#shopping_cart_container > a > svg > path")).Click();
            driver.FindElement(By.CssSelector("#cart_contents_container > div > div.cart_footer > a.btn_action.checkout_button")).Click();
            driver.FindElement(By.Id("first-name")).SendKeys("Stephen");
            driver.FindElement(By.Id("last-name")).SendKeys("Steven");
            driver.FindElement(By.Id("postal-code")).SendKeys("12345");
            driver.FindElement(By.CssSelector("#checkout_info_container > div > form > div.checkout_buttons > input")).Click();



          




        }


        [TearDown]
        public void TearDown()
        {
            // Close the driver

            driver.Close();
        }




    }
}
