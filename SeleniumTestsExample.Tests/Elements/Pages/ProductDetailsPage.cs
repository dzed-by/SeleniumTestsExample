using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumTestsExample.Framework.Utils;
using SeleniumTestsExample.Tests.Models;

namespace SeleniumTestsExample.Tests.Elements.Pages
{
    /// <summary>
    /// Класс для работы со страницей детальной информации о продукте.
    /// </summary>
    public class ProductDetailsPage
    {
        [FindsBy(How.XPath, "//*[@class='inventory_details']")]
        private IWebElement _pageElement;

        [FindsBy(How.XPath, "//*[contains(@class, 'inventory_details_name')]")]
        private IWebElement _name;

        [FindsBy(How.XPath, "//*[contains(@class, 'inventory_details_desc ')]")]
        private IWebElement _description;

        [FindsBy(How.XPath, "//*[@class = 'inventory_details_price']")]
        private IWebElement _price;

        [FindsBy(How.XPath, "//*[contains(@data-test, 'add-to-cart')]")]
        private IWebElement _addToCartButton;

        /// <summary>
        /// Создает новый экземпляр класса <see cref="ProductDetailsPage"/>.
        /// </summary>
        /// <param name="driver"> WebDriver. </param>
        public ProductDetailsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Получить информацию о видимости страницы детальной информации о продукте.
        /// </summary>
        /// <returns> Флаг видимости страницы продуктов. </returns>
        public bool IsOpened()
        {
            try
            {
                return _pageElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// ПОлучить информацию о продукте со страницы детальной информации о продукте.
        /// </summary>
        /// <returns> Информация о продукте. </returns>
        public ProductModel GetProductInfo()
        {
            return new ProductModel()
            {
                Name = GetName(),
                Description = GetDescription(),
                Price = GetPrice()
            };
        }

        private string GetName()
        {
            return _name.Text;
        }

        private string GetDescription()
        {
            return _description.Text;
        }

        private double GetPrice()
        {
            return double.Parse(_price.Text.GetPriceWithoutCurrency());
        }
    }
}
