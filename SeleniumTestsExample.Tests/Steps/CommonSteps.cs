using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using SeleniumTestsExample.Framework;

namespace SeleniumTestsExample.Tests.Steps
{
    public class CommonSteps
    {
        private readonly IWebDriver _driver;
        private readonly IConfiguration _config;
        public CommonSteps(WebDriverProvider driverProvider, IConfiguration config)
        {
            _driver = driverProvider.GetDriver();
            _config = config;
        }

        public void OpenStartPage()
        {
            _driver.Url = _config["Url"];
            _driver.Manage().Window.Maximize();
        }
    }
}
