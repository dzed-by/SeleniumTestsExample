using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumTestsExample.Tests.Elements.Pages
{
    /// <summary>
    /// Класс для работы со страницей логина.
    /// </summary>
    public class LoginPage
    {
        [FindsBy(How.Id, "login_button_container")]
        private IWebElement _pageElement;

        [FindsBy(How.Id, "user-name")]
        private IWebElement _userNameInput;

        [FindsBy(How.Id, "password")]
        private IWebElement _passwordInput;

        [FindsBy(How.Id, "login-button")]
        private IWebElement _loginButton;

        [FindsBy(How.XPath, "//*[@data-test='error']")]
        private IWebElement _errorMessage;

        /// <summary>
        /// Создает новый экземпляр класса <see cref="LoginPage"/>.
        /// </summary>
        /// <param name="driver"> WebDriver. </param>
        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Получить информацию о видимости страницы логина.
        /// </summary>
        /// <returns> Флаг видимости страницы логина. </returns>
        public bool IsOpened()
        {
            try
            {
                return _pageElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Ввести имя пользователя.
        /// </summary>
        /// <param name="userName"> Имя пользователя.</param>
        /// <returns> Ссылка на себя для Fluent-Конфигурирования. </returns>
        public LoginPage EnterUserName(string userName)
        {
            _userNameInput.SendKeys(userName);
            return this;
        }

        /// <summary>
        /// Ввести пароль.
        /// </summary>
        /// <param name="password"></param>
        /// <returns> Ссылка на себя для Fluent-Конфигурирования. </returns>
        public LoginPage EnterPassword(string password)
        {
            _passwordInput.SendKeys(password);
            return this;
        }

        /// <summary>
        /// Нажать кнопку логин.
        /// </summary>
        /// <returns> Ссылка на себя для Fluent-Конфигурирования. </returns>
        public LoginPage ClickLoginButton()
        {
            _loginButton.Click();
            return this;
        }

        /// <summary>
        ///  Получить информацию о видимости сообщения об ошибке на странице логина.
        /// </summary>
        /// <returns> Флаг видимости сообщения об ошибке. </returns>
        public bool IsErrorMessageDisplayed()
        {
            return _errorMessage.Displayed;
        }

        /// <summary>
        /// Получить текст сообщения об ошибке.
        /// </summary>
        /// <returns> Текс сообщения об ошибке. </returns>
        public string GetErrorMessageText()
        {
            return _errorMessage.Text;
        }
    }
}
