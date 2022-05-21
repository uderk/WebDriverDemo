using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Tests
{
    public class SeleniumTestsDemo
    {
        private WebDriver driver;
        [OneTimeSetUp]
        public void SetupOpenAndNavigate()
        {
            this.driver = new ChromeDriver(@"D:\venko\QAautomation\WebDriverDemo\NUnitSeleniumTest\bin\Debug\netcoreapp2.1");
            driver.Url = "https://softuni.bg";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestTitle()
        {
            //driver.Manage().Window.Size();
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";
            Assert.AreEqual(expectedTitle, driver.Title);
        }

        [Test]
        public void TestAssertAboutUsTitle()
        {
          //  driver.Url = "https://softuni.bg";
            var zaNasElement =driver.FindElement(By.XPath("/html/body/div[1]/div[1]/header/nav/div[1]/ul/li[1]/a/span"));
            zaNasElement.Click();
            //assert
            //Thread.Sleep(5000);
            string expectedTitle = "За нас - Софтуерен университет";
            Assert.AreEqual(expectedTitle, driver.Title);
        }

        [Test]
        public void Test_Login_InvalidUserNameAndPassword()
        {
            driver.FindElement(By.CssSelector(".softuni-btn-primary")).Click();

            // Locate username field by ID
            // var usernmameField = driver.FindElement(By.Id("username"));

            // Locate username field by TagName
            var usernmameField_ByName = driver.FindElement(By.Name("username"));
            var usernmameField_CSSSelector = driver.FindElement(By.CssSelector("#username"));

            // IWebElement usernmameField = driver.FindElement(By.Id("username"));

            usernmameField_CSSSelector.Click();
            usernmameField_CSSSelector.SendKeys("user1");//as if the user writes user1 on the keypad
            // usernmameField_CSSSelector.Clear();
            // driver.FindElement(By.Id("username")).SendKeys("user1");

            // usernmameField_CSSSelector.SendKeys(Keys.Tab);

            driver.FindElement(By.Id("password-input")).Click();
            driver.FindElement(By.Id("password-input")).SendKeys("user1");

            driver.FindElement(By.CssSelector(".softuni-btn")).Click();

            Assert.That(driver.FindElement(By.CssSelector("li")).Text, Is.EqualTo("Невалидно потребителско име или парола"));

        }
        [Test]
        public void SearchForQA()
        {
            driver.Url = "https://softuni.bg";
            //find and click on search button
            driver.FindElement(By.CssSelector(".header-search-dropdown-link .fa-search")).Click();
            var searchBox = driver.FindElement(By.CssSelector(".container > form #search-input"));
            searchBox.Click();
            //search for QA 
            searchBox.SendKeys("QA");
            searchBox.SendKeys(Keys.Enter);

            var resultField = driver.FindElement(By.CssSelector(".search-title")).Text;

            var expectedVaue = "Резултати от търсене на “QA”";

            Assert.That(resultField, Is.EqualTo(expectedVaue));
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}