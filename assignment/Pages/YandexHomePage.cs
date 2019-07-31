using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace assignment.Pages
{
    public class YandexHomePage
    {
        private static IWebDriver driver;

        private static IWebElement Logo => driver.FindElement(By.XPath("//div[@class='home-logo__default']"));

        public static readonly string pageUrl = "https://yandex.ru/";
        private static readonly string pageTitle = "Яндекс";

        public YandexHomePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void CheckPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(driver => Logo);

            Assert.AreEqual(pageUrl, driver.Url, "Page URL is Unexpected");
            Assert.AreEqual(pageTitle, driver.Title, "Page Title is Unexpected");
        }
    }
}
