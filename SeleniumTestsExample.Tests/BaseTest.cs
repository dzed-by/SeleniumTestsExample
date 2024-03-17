using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTestsExample.Framework;
using SeleniumTestsExample.Framework.Extensions;
using SeleniumTestsExample.Tests.Steps;
using Serilog;

namespace SeleniumTestsExample.Tests
{
    /// <summary>
    /// Базовый класс для тестов.
    /// Содержит настройку Di-контейнера и настройки тестов.
    /// </summary>
    [TestFixture]
    public class BaseTest : SetupFixture
    {
        private IWebDriver _driver => GetRequiredService<WebDriverProvider>().GetDriver();

        /// <summary> Логгер. </summary>
        protected ILogger Logger => GetRequiredService<ILogger>();

        /// <summary> Конфигурация. </summary>
        protected IConfiguration Config => GetRequiredService<IConfiguration>();

        /// <summary> Шаги для работы со страницей логина. </summary>
        protected LoginPageSteps LoginPageSteps => GetRequiredService<LoginPageSteps>();

        /// <summary> Общие шаги для тестов. </summary>
        protected CommonSteps CommonSteps => GetRequiredService<CommonSteps>();

        /// <summary> Шаги для работы со страницей продуктов. </summary>
        protected ProductsPageSteps ProductsPageSteps => GetRequiredService<ProductsPageSteps>();

        /// <summary> Шаги для работы со старницей етальной информации о продукте. </summary>
        protected ProductDetailsPageSteps ProductDetailsPageSteps => GetRequiredService<ProductDetailsPageSteps>();

        /// <summary>
        /// Настраивает DI-контейнер.
        /// </summary>
        /// <param name="services"> Коллекция сервисов. </param>
        protected override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddSingleton<IConfiguration>(
                new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build());

            services
                .AddTestsLogging()
                .AddTransient<LoginPageSteps>()
                .AddTransient<CommonSteps>()
                .AddTransient<ProductsPageSteps>()
                .AddTransient<ProductDetailsPageSteps>();
        }

        /// <summary>
        /// Действия, выполняемые перед каждым тестом.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            Logger.Information($"Начало теста {TestContext.CurrentContext.Test.FullName}");
        }

        /// <summary>
        /// Действия, выполняемые после каждого теста.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Logger.Information($"Окончание теста {TestContext.CurrentContext.Test.FullName}\n");
        }

        /// <summary>
        /// Действия, выполняемые после всех тестов.
        /// </summary>
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
            _driver.Close();
        }
    }
}
