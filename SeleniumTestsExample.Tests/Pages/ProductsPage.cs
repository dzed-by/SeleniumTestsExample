using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumTestsExample.Tests.Pages
{
    class ProductsPage
    {
        private readonly By _pageLocator;
        private readonly IWebDriver _driver;

        public ProductsPage(IWebDriver driver)
        {
            _pageLocator = By.XPath("//span[text()='Products']");
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public bool IsOpened()
        {
            return _driver.FindElement(_pageLocator).Displayed;
        }
    }
}
