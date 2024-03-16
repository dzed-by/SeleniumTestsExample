using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumTestsExample.Framework
{
    public class WebDriverProvider
    {
        private IWebDriver _driver;
        private readonly IConfiguration _configuration;

        public WebDriverProvider(IConfiguration config)
        {
            _configuration = config;
        }

        public IWebDriver GetDriver()
        {
            if(_driver == null)
            {
                CreateDriverInstance();
            }

            return _driver;
        }

        private void CreateDriverInstance()
        {
            var browser = _configuration["Browser"];
            switch (browser)
            {
                case "Chrome":
                    {
                        _driver = new ChromeDriver();
                        return;
                    };
                default: throw new ArgumentException($"Тип праузера '{browser}' не поддерживается.");
            }
        }
    }
}
