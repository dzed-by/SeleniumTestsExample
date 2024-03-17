using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumTestsExample.Framework.Elements;
using SeleniumTestsExample.Tests.Elements.Forms;
using SeleniumTestsExample.Tests.Models;
using System.Collections.Generic;

namespace SeleniumTestsExample.Tests.Elements.Pages
{
    /// <summary>
    /// Класс для роботы со страницей продуктов.
    /// </summary>
    public class ProductsPage
    {
        private readonly IWebDriver _driver;

        private By _productFormLocator = By.XPath("//*[@class = 'inventory_item']");
        private By _sortingSelectLocator = By.XPath("//select[@class='product_sort_container']");

        private List<ProductCardForm> _products = new List<ProductCardForm>();
        private readonly SelectElement _sortingSelect;

        [FindsBy(How.XPath, "//span[text()='Products']")]
        private IWebElement _pageElement;

        /// <summary>
        /// Создает новый экземпляр класса <see cref="ProductsPage"/>.
        /// </summary>
        /// <param name="driver"> WebDriver. </param>
        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
            _sortingSelect = new SelectElement(_sortingSelectLocator, driver);
            PageFactory.InitElements(driver, this);
        }


        /// <summary>
        /// Получить информацию о видимости страницы продуктов.
        /// </summary>
        /// <returns> Флаг видимости страницы логина. </returns>
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
        /// Получить информацию о продукте из карточки продукта.
        /// </summary>
        /// <param name="productNumberInList"> Номер продукта в списке на странице. </param>
        /// <returns> Информация о продукте. </returns>
        public ProductModel GetProductInfo(int productNumberInList)
        {
            InitializeProductsList();

            return _products[productNumberInList].GetProductInfo();
        }

        /// <summary>
        /// Добавить продукт в корзину.
        /// </summary>
        /// <param name="productNumberInList"> Номер продукта в списке на странице. </param>
        /// <returns> Информация о продукте, добавленном в карзину. </returns>
        public ProductModel AddProductToCart(int productNumberInList)
        {
            InitializeProductsList();

             var productInfo = _products[productNumberInList].GetProductInfo();
            _products[productNumberInList].AddProductToCart();

            return productInfo;
        }

        /// <summary>
        /// Открыть старницу детальной информации о продукте через карточку продукта.
        /// </summary>
        /// <param name="productNumberInList"> Номер продукта в списке на странице. </param>
        public void OpenPoductDetails(int productNumberInList)
        {
            InitializeProductsList();
            _products[productNumberInList].OpenProductDetailsPage();
        }

        /// <summary>
        /// Отсортировать список продуктов опрделенным образом.
        /// </summary>
        /// <param name="optionName"> Описание опции сортировки продуктов. </param>
        public void SorProductByOptionName(string optionName)
        {
           _sortingSelect.SelectByname(optionName);
        }

        /// <summary>
        /// Получить список описания рподуктов на странице.
        /// </summary>
        /// <returns> Список с описание продуктов на странице. </returns>
        public List<ProductModel> GetListedProductsInfo()
        {
            var productsInfo = new List<ProductModel>();
            InitializeProductsList();
            foreach(var product in _products)
            {
                productsInfo.Add(product.GetProductInfo());
            }
            
            return productsInfo;
        }

        private void InitializeProductsList()
        {
            _products.Clear();
            var forms = _driver.FindElements(_productFormLocator);
            foreach (var form in forms)
            {
                _products.Add(new ProductCardForm(form));
            }
        }
    }
}
