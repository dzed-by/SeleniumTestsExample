using NUnit.Framework;
using SeleniumTestsExample.Tests.Steps;
using Serilog;

namespace SeleniumTestsExample.Tests.Tests
{
    /// <summary>
    /// Тесты для страницы логина.
    /// </summary>
    [Category("LoginPage")]
    public class LoginPageTests : BaseTest
    {
        /// <summary>
        /// Тест на авторизацию пользователя с валидными данными. Ожидается успешная авторизация.
        /// </summary>
        [Test]
        public void Login_ValidUserWithValidInput_ShouldOpenProductsPage()
        {
            CommonSteps.OpenStartPage();

            LoginPageSteps.EnterCredentialsAndLogin(Config["StandartUserLogin"], Config["Password"]);

            Logger.Information("Проверка открытия страницы продуктов полсе логина.");
            Assert.IsTrue(
                ProductsPageSteps.IsPageOpened(), "После успешного логина страница с продуктами должно открыться.");
        }

        /// <summary>
        /// Тест на ошибку авторизации заблокированного опльзователя. Ожидается ошибка с опрделенным сообщением.
        /// </summary>
        [Test]
        public void Login_LockedUserWithValidInput_ShouldShowErrorMessage()
        {
            CommonSteps.OpenStartPage();

            LoginPageSteps.EnterCredentialsAndLogin(Config["LockedUserLogin"], Config["Password"]);

            Logger.Information("Проверка отображения сообщения об ошибке и его содержание.");
            Assert.IsTrue(
                LoginPageSteps.IsErrorMessageDisplayed(),
                "При логине с заблокированным пользователем должно отобразиться сообщение об ошибке.");

            Assert.IsTrue(
                LoginPageSteps.GetErrorMesssageText().Contains("user has been locked out"),
                "При логине с заблокированным пользователем сообщение об ошибке должно быть соответствующим.");
        }

        /// <summary>
        /// Тест на валидацию данным пользователя. Ввод некорректный данных для авторизации.
        /// Ожидается ошибка с опрделенным сообщением.
        /// </summary>
        /// <param name="userName"> Имя пользователя. </param>
        /// <param name="password"> Пароль. </param>
        /// <param name="errorMessageText"> Ожидаеммое сообщение об ошибке. </param>
        [TestCase("abc", "", "Password is required")]
        [TestCase("", "abc", "Username is required")]
        [TestCase("", "", "Username is required")]
        [TestCase("abc", "abc", " Username and password do not match any user in this service")]
        public void Login_LoginWithInValidInput_ShouldShowErrorMessage(
            string userName, string password, string errorMessageText)
        {
            CommonSteps.OpenStartPage();

            LoginPageSteps.EnterCredentialsAndLogin(userName, password);


            Logger.Information("Проверка отображения сообщения об ошибке и его содержание.");
            Assert.IsTrue(
                LoginPageSteps.IsErrorMessageDisplayed(),
                "При логине с неверными данными, должно отобразится сообщение об ошибке.");
            Assert.IsTrue(
                LoginPageSteps.GetErrorMesssageText().Contains(errorMessageText),
                "При логине с неверными данными, сообщение об ошибке должно быть соответствующим.");
        }
    }
}