using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

namespace Tests
{
    public class SoftUniSeleniumTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNamePageTitle()
        {
            var driver = new ChromeDriver();
            driver.Url = "https://softuni.bg";
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";

            Assert.AreEqual(expectedTitle, driver.Title);
        }
    }
}