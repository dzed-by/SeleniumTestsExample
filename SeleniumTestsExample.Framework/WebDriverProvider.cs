using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumTestsExample.Framework
{
    /// <summary>
    /// Класс, продоставляющий инстанс WebDriver.
    /// </summary>
    public class WebDriverProvider
    {
        private IWebDriver _driver;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Создает новый экземпляр класса <see cref="WebDriverProvider"/>.
        /// </summary>
        public WebDriverProvider(IConfiguration config)
        {
            _configuration = config;
        }

        /// <summary>
        /// Получить WebDriver для работы.
        /// При вызове впервые - инициализирует WebDriver. Затем возвращает инициализорованный инстанс. 
        /// </summary>
        /// <returns> WebDriver. </returns>
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
