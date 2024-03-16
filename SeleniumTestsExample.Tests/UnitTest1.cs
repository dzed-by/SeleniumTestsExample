using NUnit.Framework;

namespace SeleniumTestsExample.Tests
{
    public class Tests : BaseTest
    {
        [Test]
        public void Test1()
        {
            Driver.Url = "https://www.saucedemo.com/";
            Driver.Manage().Window.Maximize();
        }
    }
}