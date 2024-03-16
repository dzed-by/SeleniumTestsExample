using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTestsExample.Framework;
using SeleniumTestsExample.Tests.Pages;

namespace SeleniumTestsExample.Tests.Steps
{
    public class CommonSteps
    {
        private readonly IWebDriver _driver;
        private readonly IConfiguration _config;
        private readonly LoginPage _loginPage;

        public CommonSteps(WebDriverProvider driverProvider, IConfiguration config)
        {
            _driver = driverProvider.GetDriver();
            _config = config;
            _loginPage = new LoginPage(driverProvider.GetDriver());
        }

        public void OpenStartPage()
        {
            _driver.Url = _config["Url"];
            _driver.Manage().Window.Maximize();
            Assert.IsTrue(_loginPage.IsOpened());
        }
    }
}
