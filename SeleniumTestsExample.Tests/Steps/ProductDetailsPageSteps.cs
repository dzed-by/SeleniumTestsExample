using SeleniumTestsExample.Framework;
using SeleniumTestsExample.Tests.Elements.Pages;
using SeleniumTestsExample.Tests.Models;
using Serilog;

namespace SeleniumTestsExample.Tests.Steps
{
    /// <summary>
    /// Шаги для работы со старницей етальной информации о продукте.
    /// </summary>
    public class ProductDetailsPageSteps
    {
        private readonly ProductDetailsPage _productDetailsPage;
        private readonly ILogger _logger;

        /// <summary>
        /// Создает новый экземпляр класса <see cref="ProductDetailsPageSteps"/>.
        /// </summary>
        /// <param name="driverProvider"> Провайдер WebDriver. </param>
        /// <param name="logger"> Логгер. </param>
        public ProductDetailsPageSteps(WebDriverProvider driverProvider, ILogger logger)
        {
            _productDetailsPage = new ProductDetailsPage(driverProvider.GetDriver());
            _logger = logger;
        }

        /// <summary>
        /// ПОлучить информацию о продукте со страницы детальной информации о продукте.
        /// </summary>
        /// <returns> Информация о продукте. </returns>
        public ProductModel GetProductInfo()
        {
            _logger.Information("Получение информации о продукте со странице детальной информации.");
            return _productDetailsPage.GetProductInfo();
        }
    }
}
