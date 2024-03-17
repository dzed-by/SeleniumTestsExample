using SeleniumTestsExample.Framework;
using SeleniumTestsExample.Tests.Elements.Pages;
using SeleniumTestsExample.Tests.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumTestsExample.Tests.Steps
{
    /// <summary>
    /// Шаги для работы со страницей продуктов.
    /// </summary>
    public class ProductsPageSteps
    {
        private readonly ProductsPage productsPage;
        private readonly ILogger _logger;

        /// <summary>
        /// Создает новый экземпляр класса <see cref="ProductsPageSteps"/>.
        /// </summary>
        /// <param name="driverProvider"> Провайдер WebDriver. </param>
        /// <param name="logger"> Логгер. </param>
        public ProductsPageSteps(WebDriverProvider driverProvider, ILogger logger)
        {
            productsPage = new ProductsPage(driverProvider.GetDriver());
            _logger = logger;
        }

        /// <summary>
        /// Получить информацию о видимости страницы продуктов.
        /// </summary>
        /// <returns> Флаг видимости страницы логина. </returns>
        public bool IsPageOpened()
        {
            _logger.Information("Получение иформации об отображении страницы продуктов.");
            return productsPage.IsOpened();
        }

        // <summary>
        /// Добавить продукт в корзину.
        /// </summary>
        /// <param name="productNumberInList"> Номер продукта в списке на странице. </param>
        /// <returns> Информация о продукте, добавленном в карзину. </returns>
        public ProductModel AddProductToCart(int produtcNumberInList)
        {
            if(produtcNumberInList < 0)
                throw new ArgumentException("Номер продукта в корзине не может быть отрицательным.");

            _logger.Information($"Добавление продукта {produtcNumberInList + 1} в корзину со страницы продуктов.");
            return productsPage.AddProductToCart(produtcNumberInList);
        }

        /// <summary>
        /// Получить информацию о продукте из карточки продукта.
        /// </summary>
        /// <param name="productNumberInList"> Номер продукта в списке на странице. </param>
        /// <returns> Информация о продукте. </returns>
        public ProductModel GetProductInfo(int produtcNumberInList)
        {
            if (produtcNumberInList < 0)
                throw new ArgumentException("Номер продукта в корзине не может быть отрицательным.");

            _logger.Information($"Получение информации о продукте {produtcNumberInList + 1} со страницы продуктов.");
            return productsPage.GetProductInfo(produtcNumberInList);
        }

        /// <summary>
        /// Открыть старницу детальной информации о продукте через карточку продукта.
        /// </summary>
        /// <param name="productNumberInList"> Номер продукта в списке на странице. </param>
        public void OpenProductDetails(int produtcNumberInList)
        {
            if (produtcNumberInList < 0)
                throw new ArgumentException("Номер продукта в корзине не может быть отрицательным.");

            _logger.Information($"Открытие страницы с деталями о продукте {produtcNumberInList + 1} со страницы продуктов.");
            productsPage.OpenPoductDetails(produtcNumberInList);
        }

        /// <summary>
        /// Отсортировать список продуктов опрделенным образом.
        /// </summary>
        /// <param name="optionName"> Описание опции сортировки продуктов. </param>
        public void SortProductsByOption(string optionName)
        {
            _logger.Information($"Сотрировка продуктов {optionName}.");
            productsPage.SorProductByOptionName(optionName);
        }

        /// <summary>
        /// Получить список наименования продуктов.
        /// </summary>
        public List<string> GetProductNamesList()
        {
            _logger.Information("Получение списка имен продуктов.");
            return productsPage.GetListedProductsInfo().Select(x => x.Name).ToList();
        }

        /// <summary>
        /// Получить список цен продуктов.
        /// </summary>
        public List<double> GetProductPricesList()
        {
            _logger.Information("Получение списка цен продуктов.");
            return productsPage.GetListedProductsInfo().Select(x => x.Price).ToList();
        }
    }
}
