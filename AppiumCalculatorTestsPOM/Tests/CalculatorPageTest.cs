using OpenQA.Selenium.Appium.Windows;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using AppiumCalculatorTestsPOM.Pages;
using static System.Net.Mime.MediaTypeNames;

namespace AppiumCalculatorTestsPOM.Tests
{
    public class CalculatorPageTest : BaseTest
    {
        private CalculatorPage page;

        [SetUp]
        public void Setup()
        {
            this.page = new CalculatorPage(driver);
        }

        [Test]
        public void Test_SumTwoPositiveNumbers()
        {
            var result = page.CalculateTwoNumbers("44", "11");
            Assert.That(result, Is.EqualTo("55"));
        }
    }
}