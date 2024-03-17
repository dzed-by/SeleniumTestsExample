using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using System;

namespace SeleniumTestsExample.Framework.Extensions
{
    /// <summary>
    /// Класс расширений для коллекции сервисов.
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Настраивает логирование в тестах.
        /// При необходимости можно повлиять на поведение с помощью ключей конфигурации.
        /// Ключ                    | Используемое умолчание
        /// ------------------------|-------------------------------------------------------------------------------------
        /// Console:MinimumLevel    | Debug
        /// Console:OutputTemplate  | [{Timestamp:HH:mm:ss} {Level:u3}]<{SourceContext}> {Message:lj} {NewLine}{Exception}
        /// </summary>
        /// <param name="services"> Коллекция сервисов. </param>
        /// <returns> Ссылка на себя для Fluent-Конфигурирования. </returns>
        public static IServiceCollection AddTestsLogging(this IServiceCollection services)
            => services
                .AddSingleton<ILogger>(sp => new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .ReadFrom.Configuration(sp.GetRequiredService<IConfiguration>())
                    .Enrich.FromLogContext()
                    .WriteTo.Console(
                        outputTemplate: sp.GetService<IConfiguration>()?["Console:OutputTemplate"] ?? "[{Timestamp:HH:mm:ss} {Level:u3}]<{SourceContext}> {Message:lj} {NewLine}{Exception}",
                        restrictedToMinimumLevel: Enum.Parse<LogEventLevel>(sp.GetService<IConfiguration>()?["Console:MinimumLevel"] ?? "Debug"))
                    .WriteTo.File("./logs.txt")
                    .CreateLogger());
    }
}
