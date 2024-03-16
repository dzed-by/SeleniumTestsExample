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
        protected IConfiguration Config => GetRequiredService<IConfiguration>();
        protected LoginPageSteps LoginPageSteps => GetRequiredService<LoginPageSteps>();
        protected CommonSteps CommonSteps => GetRequiredService<CommonSteps>();
        protected ProductsPageSteps ProductsPageSteps => GetRequiredService<ProductsPageSteps>();

        protected override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddSingleton<IConfiguration>(
                new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build());

            services
                .AddTransient<LoginPageSteps>()
                .AddTransient<CommonSteps>()
                .AddTransient<ProductsPageSteps>();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Close();
        }
    }
}
