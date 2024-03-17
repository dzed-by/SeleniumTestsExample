using FluentAssertions;
using NUnit.Framework;

namespace SeleniumTestsExample.Tests.Tests
{
    /// <summary>
    /// Тесты для страницы продутков.
    /// </summary>
    [Category("ProductsPage")]
    public class ProductsPageTests : BaseTest
    {
        /// <summary>
        /// Тест на корректное отображение карточки продукта. Сравнение с страницей детальной информации о продукте. 
        /// </summary>
        [Test]
        public void ProductsPage_ValidUser_ProductInfoOnPageShouldMatchProductDetailsPage()
        {
            CommonSteps.OpenStartPageAndLogin(Config["StandartUserLogin"], Config["Password"]);

            var expectedProductDescr = ProductsPageSteps.GetProductInfo(0);

            ProductsPageSteps.OpenProductDetails(0);
            var productDetailsInfo = ProductDetailsPageSteps.GetProductInfo();

            Logger.Information("Проверка совпадание информации о продукте на странице продуктов и странице с детальной информацией о продукте.");
            productDetailsInfo.Should().BeEquivalentTo(expectedProductDescr, "Информация о продукте должно совпрадать.");
        }

        /// <summary>
        /// Тест на корректную сортироку продуктов по имени.
        /// </summary>
        /// <param name="sortOption"> Вариант сортировки по имени. </param>
        /// <param name="listSortDirection"> Ожидаеммое направление сортировки. </param>
        [TestCase("Name (Z to A)", System.ComponentModel.ListSortDirection.Descending)]
        [TestCase("Name (A to Z)", System.ComponentModel.ListSortDirection.Ascending)]
        public void ProductsPage_ValidUser_SortByNameShouldWork(string sortOption, System.ComponentModel.ListSortDirection listSortDirection)
        {
            CommonSteps.OpenStartPageAndLogin(Config["StandartUserLogin"], Config["Password"]);

            ProductsPageSteps.SortProductsByOption(sortOption);

            var productNames = ProductsPageSteps.GetProductNamesList();

            Logger.Information("Проверка сортировки продуктов на странице продуктов.");
            if (listSortDirection.Equals(System.ComponentModel.ListSortDirection.Descending))
            {
                productNames.Should().BeInDescendingOrder($"При сортировке {sortOption}, имена продуктов должны быть по убыванию.");
            }
            else
            {
                productNames.Should().BeInAscendingOrder($"При сортировке {sortOption}, имена продуктов должны быть по возрастанию.");
            }              
        }

        /// <summary>
        /// Тест на корректную сортироку продуктов по цене.
        /// </summary>
        /// <param name="sortOption"> Вариант сортировки по цене. </param>
        /// <param name="listSortDirection"> Ожидаеммое направление сортировки. </param>
        [TestCase("Price (low to high)", System.ComponentModel.ListSortDirection.Ascending)]
        [TestCase("Price (high to low)", System.ComponentModel.ListSortDirection.Descending)]
        public void ProductsPage_ValidUser_SortByPriceShouldWork(string sortOption, System.ComponentModel.ListSortDirection listSortDirection)
        {
            CommonSteps.OpenStartPageAndLogin(Config["StandartUserLogin"], Config["Password"]);

            ProductsPageSteps.SortProductsByOption(sortOption);

            var productNames = ProductsPageSteps.GetProductPricesList();

            Logger.Information($"Проверка сортировки продуктов на странице продуктов.");
            if (listSortDirection.Equals(System.ComponentModel.ListSortDirection.Descending))
            {
                productNames.Should().BeInDescendingOrder($"При сортировке {sortOption}, цены продуктов должны быть по убыванию.");
            }
            else
            {
                productNames.Should().BeInAscendingOrder($"При сортировке {sortOption}, wtys продуктов должны быть по возрастанию.");
            }
        }
    }
}
