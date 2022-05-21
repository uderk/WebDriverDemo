using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebDriverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //create new Chrome Brower Instance 
            var driver = new ChromeDriver();

            //navigate to wikioedia
            driver.Url = "https://wikipedia.org";
            Console.WriteLine("Current title " + driver.Title);

            //locate element by Id
            var searchField = driver.FindElement(By.Id("searchInput"));
            //click on the element, enter QA, press enter
            searchField.Click();
            searchField.SendKeys("QA");
            searchField.SendKeys(Keys.Enter);

            Console.WriteLine("Title after search "+ driver.Title);
            Thread.Sleep(3000);
            //close brower
            driver.Quit();
        }
    }
}
