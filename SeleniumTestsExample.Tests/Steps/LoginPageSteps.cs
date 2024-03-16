using OpenQA.Selenium;
using SeleniumTestsExample.Framework;
using SeleniumTestsExample.Tests.Pages;

namespace SeleniumTestsExample.Tests.Steps
{
    public class LoginPageSteps
    {
        private readonly LoginPage _loginPage;

        public LoginPageSteps(WebDriverProvider driverProvider)
        {
            _loginPage = new LoginPage(driverProvider.GetDriver());
        }

        public void EnterCredentialsAndLogin(string userName, string password)
        {
            _loginPage
                .EnterUserName(userName)
                .EnterPassword(password)
                .ClickLoginButton();
        }

        public bool IsPageOpened()
        {
            return _loginPage.IsOpened();
        }

        public bool IsErrorMessageDisplayed()
        {
            return _loginPage.IsErrorMessageDisplayed();
        }

        public string GetErrorMesssageText()
        {
            return _loginPage.GetErrorMessageText();
        }
    }
}
