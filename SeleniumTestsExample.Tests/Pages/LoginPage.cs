using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumTestsExample.Tests.Pages
{
    public class LoginPage
    {
        private readonly By _pageLocator;
        private readonly IWebDriver _driver;

        [FindsBy(How.Id, "user-name")]
        private IWebElement _userNameInput;

        [FindsBy(How.Id, "password")]
        private IWebElement _passwordInput;

        [FindsBy(How.Id, "login-button")]
        private IWebElement _loginButton;

        [FindsBy(How.XPath, "//*[@data-test='error']")]
        private IWebElement _errorMessage;

        public LoginPage(IWebDriver driver)
        {
            _pageLocator = By.Id("login_button_container");
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public bool IsOpened()
        {
            return _driver.FindElement(_pageLocator).Displayed;
        }

        public LoginPage EnterUserName(string userName)
        {
            _userNameInput.SendKeys(userName);
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            _passwordInput.SendKeys(password);
            return this;
        }

        public LoginPage ClickLoginButton()
        {
            _loginButton.Click();
            return this;
        }

        public bool IsErrorMessageDisplayed()
        {
            return _errorMessage.Displayed;
        }

        public string GetErrorMessageText()
        {
            return _errorMessage.Text;
        }
    }
}
