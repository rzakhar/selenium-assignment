using OpenQA.Selenium;

namespace assignment.Pages
{
    public class DuckDuckGoHomePage
    {
        private static IWebDriver driver;

        private static IWebElement SearchInput => driver.FindElement(By.XPath("//input[@id='search_form_input_homepage']"));

        public static readonly string pageUrl = "https://duckduckgo.com/";

        public DuckDuckGoHomePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        
        public void SearchFor(string query)
        {
            SearchInput.SendKeys(query);
            SearchInput.SendKeys("\n");
        }
    }
}
