using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.Diagnostics;

namespace Tests
{
    public class WebDriverCalculatorTests
    {
        private ChromeDriver driver;

        [OneTimeSetUp]
        public void OpenAndNavigate()
        {
            var options = new ChromeOptions(); //headless options, browser is not opend, while executing tests
            //in some browser it could change some elements, for example locations 
           // options.AddArgument("--haedless");
         /*   if(!Debugger.IsAttached)
            {
                options.AddArgument("--headless");//in debug mode will open browser
            }
            */

            this.driver = new ChromeDriver(@"D:\venko\QAautomation\WebDriverDemo\DemoDataDrivenSeleniumTest\bin\Debug\netcoreapp2.1",options);
            driver.Url = "https://number-calculator.nakov.repl.co/";
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [TestCase("5","6","+", "Result: 11")]
        [TestCase("10", "15", "+", "Result: 25")]
        public void TestCalculator(string num1, string num2,string operation, string result)
        {
            //Arrange
            var field1 = driver.FindElement(By.Id("number1"));
            var field2 = driver.FindElement(By.Id("number2"));
            var operationField = driver.FindElement(By.Id("operation"));
            var calculate = driver.FindElement(By.Id("calcButton"));
            var resultField = driver.FindElement(By.Id("result"));
            var clearFiled = driver.FindElement(By.Id("resetButton"));
            //Act
            field1.SendKeys(num1);
            field2.SendKeys(num2);
            operationField.SendKeys(operation);
            Thread.Sleep(3000);
            calculate.Click();

            
            Assert.That(result, Is.EqualTo(resultField.Text));
            clearFiled.Click();
        }
    }
}