using Microsoft.Extensions.DependencyInjection;
using System;

namespace SeleniumTestsExample.Framework
{
    /// <summary>
    /// Базовый класс с настройкмаи для тестов.
    /// Предоставляет возможность создания DI-колеекции и получение сервисов из нее.
    /// Должен быть унаследован базовым классом тестов в тестовом проекте.
    /// </summary>
    public abstract class SetupFixture : IDisposable
    {
        /// <summary>
        /// Провайдер сервисов.
        /// </summary>
        protected ServiceProvider RootProvider { get; }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="SetupFixture"/>.
        /// </summary>
        public SetupFixture()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            RootProvider = services.BuildServiceProvider();

        }

        /// <summary>
        /// Конфигурирование DI коллекции сервисов перед выполнением теста.
        /// Этот метод нужно оверрайднуть для того, чтобы разместить в коллекцию необходимые для теста сервисы.
        /// </summary>
        /// <param name="services"> Конфигурируемая коллекция сервисов. </param>
        protected virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<WebDriverProvider>();
        }

        /// <summary>
        /// Получить сервис из коллекции. Если такого сервиса нет, будет выброшено исключение.
        /// </summary>
        /// <typeparam name="TService"> Тип сервиса. </typeparam>
        /// <returns> Сервис указанного типа. </returns>
        public virtual TService GetRequiredService<TService>()
            where TService : class
            => RootProvider.GetRequiredService<TService>();

        /// <summary>
        /// Уничтожение DI-контейнера.
        /// </summary>
        public void Dispose()
        {
            RootProvider.Dispose();
        }
    }
}
