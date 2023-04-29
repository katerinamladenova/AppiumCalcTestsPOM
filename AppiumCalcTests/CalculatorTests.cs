using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumCalcTests
{
    public class CalculatorTests
    {
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\Users\Katerina.Bogdanova\Desktop\xmls\SummatorDesktopApp.exe";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions appiumOptions;


        [SetUp]
        public void OpenApplication()
        {
            this.appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", appLocation);
            appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        [TearDown]
        public void CloseApplication()
        {
            driver.Quit();
        }

        [Test]
        public void Test_SumTwoPositiveNumbers()
        {
            //Arrange
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            //Act
            firstField.SendKeys("1");
            secondField.SendKeys("2");
            calcButton.Click();

            //Assert
            Assert.That(resultField.Text, Is.EqualTo("3"));
        }

        [Test]
        public void Test_Sum_InvalidNumbers()
        {
            //Arrange
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            //Act
            firstField.Clear();
            secondField.Clear();
            firstField.SendKeys("blahblah");
            secondField.SendKeys("2");
            calcButton.Click();

            //Assert
            Assert.That(resultField.Text, Is.EqualTo("error"));
        }
    }
}