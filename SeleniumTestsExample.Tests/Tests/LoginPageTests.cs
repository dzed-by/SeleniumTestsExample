using NUnit.Framework;
using SeleniumTestsExample.Tests.Steps;
using Serilog;

namespace SeleniumTestsExample.Tests.Tests
{
    /// <summary>
    /// ����� ��� �������� ������.
    /// </summary>
    [Category("LoginPage")]
    public class LoginPageTests : BaseTest
    {
        /// <summary>
        /// ���� �� ����������� ������������ � ��������� �������. ��������� �������� �����������.
        /// </summary>
        [Test]
        public void Login_ValidUserWithValidInput_ShouldOpenProductsPage()
        {
            CommonSteps.OpenStartPage();

            LoginPageSteps.EnterCredentialsAndLogin(Config["StandartUserLogin"], Config["Password"]);

            Logger.Information("�������� �������� �������� ��������� ����� ������.");
            Assert.IsTrue(
                ProductsPageSteps.IsPageOpened(), "����� ��������� ������ �������� � ���������� ������ ���������.");
        }

        /// <summary>
        /// ���� �� ������ ����������� ���������������� ������������. ��������� ������ � ����������� ����������.
        /// </summary>
        [Test]
        public void Login_LockedUserWithValidInput_ShouldShowErrorMessage()
        {
            CommonSteps.OpenStartPage();

            LoginPageSteps.EnterCredentialsAndLogin(Config["LockedUserLogin"], Config["Password"]);

            Logger.Information("�������� ����������� ��������� �� ������ � ��� ����������.");
            Assert.IsTrue(
                LoginPageSteps.IsErrorMessageDisplayed(),
                "��� ������ � ��������������� ������������� ������ ������������ ��������� �� ������.");

            Assert.IsTrue(
                LoginPageSteps.GetErrorMesssageText().Contains("user has been locked out"),
                "��� ������ � ��������������� ������������� ��������� �� ������ ������ ���� ���������������.");
        }

        /// <summary>
        /// ���� �� ��������� ������ ������������. ���� ������������ ������ ��� �����������.
        /// ��������� ������ � ����������� ����������.
        /// </summary>
        /// <param name="userName"> ��� ������������. </param>
        /// <param name="password"> ������. </param>
        /// <param name="errorMessageText"> ���������� ��������� �� ������. </param>
        [TestCase("abc", "", "Password is required")]
        [TestCase("", "abc", "Username is required")]
        [TestCase("", "", "Username is required")]
        [TestCase("abc", "abc", " Username and password do not match any user in this service")]
        public void Login_LoginWithInValidInput_ShouldShowErrorMessage(
            string userName, string password, string errorMessageText)
        {
            CommonSteps.OpenStartPage();

            LoginPageSteps.EnterCredentialsAndLogin(userName, password);


            Logger.Information("�������� ����������� ��������� �� ������ � ��� ����������.");
            Assert.IsTrue(
                LoginPageSteps.IsErrorMessageDisplayed(),
                "��� ������ � ��������� �������, ������ ����������� ��������� �� ������.");
            Assert.IsTrue(
                LoginPageSteps.GetErrorMesssageText().Contains(errorMessageText),
                "��� ������ � ��������� �������, ��������� �� ������ ������ ���� ���������������.");
        }
    }
}