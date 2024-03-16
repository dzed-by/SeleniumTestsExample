using NUnit.Framework;
using SeleniumTestsExample.Tests.Steps;

namespace SeleniumTestsExample.Tests
{
    public class Tests : BaseTest
    {
        protected LoginPageSteps LoginPageSteps => GetRequiredService<LoginPageSteps>();
        protected CommonSteps CommonSteps => GetRequiredService<CommonSteps>();

        [Test]
        public void Test1()
        {
            CommonSteps.OpenStartPage();

            Assert.IsTrue(LoginPageSteps.IsPageOpened());

            LoginPageSteps.EnterCredentialsAndLogin("standard_user", "secret_sauce");
        }
    }
}