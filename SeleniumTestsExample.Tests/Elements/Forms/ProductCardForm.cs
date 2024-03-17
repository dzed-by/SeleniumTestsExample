using OpenQA.Selenium;
using SeleniumTestsExample.Framework.Utils;
using SeleniumTestsExample.Tests.Models;

namespace SeleniumTestsExample.Tests.Elements.Forms
{
    /// <summary>
    /// Класс для работы с карточкой продукта на странице продуктов.
    /// </summary>
    public class ProductCardForm
    {
        private readonly IWebElement _baseFormElement;

        private By _addToCartButtonLocator = By.XPath(".//button[contains(@data-test,'add-to-cart')]");
        private By _productPriceLocator = By.XPath(".//*[@class='inventory_item_price']");
        private By _productDescriptionLocator = By.XPath(".//*[@class='inventory_item_desc']");
        private By _productNameLocator = By.XPath(".//*[@class='inventory_item_name ']");

        /// <summary>
        /// Создает новый экземпляр класса <see cref="ProductCardForm"/>.
        /// </summary>
        /// <param name="baseFormElement"> Базовый элемент для формы, от которого будут искаться жлементы карточки. </param>
        public ProductCardForm(IWebElement baseFormElement)
        {
            _baseFormElement = baseFormElement;
        }

        /// <summary>
        /// Получить данные о продукте.
        /// </summary>
        /// <returns> Софрмированная модель информации о продукте. </returns>
        public ProductModel GetProductInfo()
        {
            return new ProductModel()
            {
                Price = GetProductPrice(),
                Name = GetProductName(),
                Description = GetProductDescription(),
            };
        }

        /// <summary>
        /// Добавить продукт в корзину через карточку продукта.
        /// </summary>
        public void AddProductToCart()
        {
            _baseFormElement.FindElement(_addToCartButtonLocator).Click();
        }

        /// <summary>
        /// Открыть детальное описание продукта через карточку продукта.
        /// </summary>
        public void OpenProductDetailsPage()
        {
            _baseFormElement.FindElement(_productNameLocator).Click();
        }

        private string GetProductName()
        {
            return _baseFormElement.FindElement(_productNameLocator).Text;
        }

        private string GetProductDescription()
        {
            return _baseFormElement.FindElement(_productDescriptionLocator).Text;
        }

        private double GetProductPrice()
        {
            var priceAsString = _baseFormElement.FindElement(_productPriceLocator).Text;

            return double.Parse(priceAsString.GetPriceWithoutCurrency());
        }
    }
}
