using NUnit.Framework;
using OpenQA.Selenium;

namespace assignment.Pages
{
    public class DuckDuckGoSearchResultsPage
    {
        private static IWebDriver driver;

        private static IWebElement TopSearchResult => driver.FindElement(By.XPath("//div[@id='r1-0']"));
        private static IWebElement TopSearchResultLink => TopSearchResult.FindElement(By.XPath("//a[@class='result__a']"));

        public DuckDuckGoSearchResultsPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public DuckDuckGoSearchResultsPage CheckTopResultLink(string url)
        {
            string href = TopSearchResultLink.GetAttribute("href");
            Assert.AreEqual(url, href, "The Top Result URL is Unexpected");

            return this;
        }

        public void ClickTopResult()
        {
            TopSearchResult.Click();
        }
    }
}
