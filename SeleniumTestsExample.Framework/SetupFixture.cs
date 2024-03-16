using Microsoft.Extensions.DependencyInjection;

namespace SeleniumTestsExample.Framework
{
    public abstract class SetupFixture
    {
        protected ServiceProvider RootProvider { get; }

        public SetupFixture()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            RootProvider = services.BuildServiceProvider();

        }

        protected virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<WebDriverProvider>();
        }

        public virtual TService GetRequiredService<TService>()
            where TService : class
            => RootProvider.GetRequiredService<TService>();
    }
}
