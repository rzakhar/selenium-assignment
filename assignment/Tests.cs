using System.IO;
using System.Reflection;
using assignment.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class Tests
    {
        readonly static IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        DuckDuckGoHomePage duckDuckGoHomePage;
        DuckDuckGoSearchResultsPage duckDuckGoSearchResultsPage;
        YandexHomePage yandexHomePage;

        [SetUp]
        public void Setup()
        {
            string duckDuckGoUrl = DuckDuckGoHomePage.pageUrl;

            driver.Navigate().GoToUrl(duckDuckGoUrl);
            driver.Manage().Window.Maximize();

            duckDuckGoHomePage = new DuckDuckGoHomePage(driver);
            duckDuckGoSearchResultsPage = new DuckDuckGoSearchResultsPage(driver);
            yandexHomePage = new YandexHomePage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test()
        {
            string searchQuery = "yandex.ru";
            string yandexUrl = YandexHomePage.pageUrl;

            duckDuckGoHomePage
                .SearchFor(searchQuery);

            duckDuckGoSearchResultsPage
                .CheckTopResultLink(yandexUrl)
                .ClickTopResult();

            yandexHomePage.
                CheckPage();
        }
    }
}
