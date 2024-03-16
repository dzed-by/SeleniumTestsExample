using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTestsExample.Framework;
using SeleniumTestsExample.Tests.Steps;

namespace SeleniumTestsExample.Tests
{
    [TestFixture]
    public class BaseTest : SetupFixture
    {
        protected IWebDriver Driver => GetRequiredService<WebDriverProvider>().GetDriver();

        protected override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddSingleton<IConfiguration>(
                new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build());

            services
                .AddTransient<LoginPageSteps>()
                .AddTransient<CommonSteps>();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Close();
        }
    }
}
