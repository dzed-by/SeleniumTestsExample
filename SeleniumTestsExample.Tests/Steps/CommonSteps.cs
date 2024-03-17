using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTestsExample.Framework;
using SeleniumTestsExample.Tests.Elements.Pages;
using Serilog;

namespace SeleniumTestsExample.Tests.Steps
{
    /// <summary>
    /// Общие шаги для тестов.
    /// </summary>
    public class CommonSteps
    {
        private readonly IWebDriver _driver;
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly LoginPage _loginPage;
        private readonly ProductsPage _productsPage;

        /// <summary>
        /// Создает новый экземпляр класса <see cref="CommonSteps"/>.
        /// </summary>
        /// <param name="driverProvider"> Провайдер WebDriver. </param>
        /// <param name="config"> Конфигурация. </param>
        /// <param name="logger"> Логгер. </param>
        public CommonSteps(WebDriverProvider driverProvider, IConfiguration config, ILogger logger)
        {
            _driver = driverProvider.GetDriver();
            _config = config;
            _loginPage = new LoginPage(driverProvider.GetDriver());
            _productsPage = new ProductsPage(driverProvider.GetDriver());
            _logger = logger;
        }

        /// <summary>
        /// Открыть стартовую страницу.И проверить открытие.
        /// </summary>
        public void OpenStartPage()
        {
            StartBrowser();

            _logger.Information("Проверка открытия страницы логина.");
            Assert.IsTrue(_loginPage.IsOpened());
        }

        /// <summary>
        /// Открыть стартовую страницу и авторизироваться. Проверить отрытие и авторирацию.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void OpenStartPageAndLogin(string userName, string password)
        {
            OpenStartPage();

            _logger.Information($"Логин пользователя {userName} с паролем {password}.");
            _loginPage
                .EnterUserName(userName)
                .EnterPassword(password)
                .ClickLoginButton();

            _logger.Information("Проверка открытия страницы продуктов.");
            Assert.IsTrue(_productsPage.IsOpened());
        }

        private void StartBrowser()
        {
            _driver.Url = _config["Url"];
            _logger.Information($"Открытие браузера на странице {_config["Url"]}.");
            _driver.Manage().Window.Maximize();
        }
    }
}
