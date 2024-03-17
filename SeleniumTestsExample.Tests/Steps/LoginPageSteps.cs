using SeleniumTestsExample.Framework;
using SeleniumTestsExample.Tests.Elements.Pages;
using Serilog;

namespace SeleniumTestsExample.Tests.Steps
{
    /// <summary>
    /// Шаги для работы со страницей логина.
    /// </summary>
    public class LoginPageSteps
    {
        private readonly LoginPage _loginPage;
        private readonly ILogger _logger;

        /// <summary>
        /// Создает новый экземпляр класса <see cref="LoginPageSteps"/>.
        /// </summary>
        /// <param name="driverProvider"> Провайдер WebDriver. </param>
        /// <param name="logger"> Логгер. </param>
        public LoginPageSteps(WebDriverProvider driverProvider, ILogger logger)
        {
            _loginPage = new LoginPage(driverProvider.GetDriver());
            _logger = logger;
        }

        /// <summary>
        /// Ввести данные пользователя и нажать логин.
        /// </summary>
        /// <param name="userName"> Имя пользователя. </param>
        /// <param name="password"> Пароль. </param>
        public void EnterCredentialsAndLogin(string userName, string password)
        {
            _logger.Information($"Логин пользователя {userName} с паролем {password}.");
            _loginPage
                .EnterUserName(userName)
                .EnterPassword(password)
                .ClickLoginButton();
        }

        /// <summary>
        /// Получить информацию о видимости страницы логина.
        /// </summary>
        /// <returns> Флаг видимости страницы логина. </returns>
        public bool IsPageOpened()
        {
            _logger.Information("Получение иформации об отображении страницы логина.");
            return _loginPage.IsOpened();
        }

        /// <summary>
        ///  Получить информацию о видимости сообщения об ошибке на странице логина.
        /// </summary>
        /// <returns> Флаг видимости сообщения об ошибке. </returns>
        public bool IsErrorMessageDisplayed()
        {
            _logger.Information("Получение иформации об отображении сообщения об ошибке на странице логина.");
            return _loginPage.IsErrorMessageDisplayed();
        }

        /// <summary>
        /// Получить текст сообщения об ошибке на странице логина.
        /// </summary>
        /// <returns> Текс сообщения об ошибке. </returns>
        public string GetErrorMesssageText()
        {
            _logger.Information("Получение текста сообщения об ошибке на странице логина.");
            return _loginPage.GetErrorMessageText();
        }
    }
}
