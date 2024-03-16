using NUnit.Framework;
using SeleniumTestsExample.Tests.Steps;

namespace SeleniumTestsExample.Tests.Tests
{
    public class LoginPageTests : BaseTest
    {
        [Test]
        public void Login_ValidUserWithValidInput_ShouldOpenProductsPage()
        {
            CommonSteps.OpenStartPage();

            LoginPageSteps.EnterCredentialsAndLogin(Config["StandartUserLogin"], Config["Password"]);

            Assert.IsTrue(ProductsPageSteps.IsPageOpened());
        }

        public void Login_LockedUserWithValidInput_ShouldShowErrorMessage()
        {
            CommonSteps.OpenStartPage();

            LoginPageSteps.EnterCredentialsAndLogin(Config["LockedUserLogin"], Config["Password"]);

            Assert.IsTrue(LoginPageSteps.IsErrorMessageDisplayed());
            Assert.IsTrue(LoginPageSteps.GetErrorMesssageText().Contains("user has been locked out"));
        }

        [TestCase("abc", "", "Password is required")]
        [TestCase("", "abc", "Username is required")]
        [TestCase("", "", "Username is required")]
        [TestCase("abc", "abc", " Username and password do not match any user in this service")]
        public void Login_LoginWithInValidInput_ShouldShowErrorMessage(string userName, string password, string errorMessageText)
        {
            CommonSteps.OpenStartPage();

            LoginPageSteps.EnterCredentialsAndLogin(userName, password);

            Assert.IsTrue(LoginPageSteps.IsErrorMessageDisplayed());
            Assert.IsTrue(LoginPageSteps.GetErrorMesssageText().Contains(errorMessageText));
        }
    }
}