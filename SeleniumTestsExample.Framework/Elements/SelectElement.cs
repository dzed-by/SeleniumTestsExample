using OpenQA.Selenium;

namespace SeleniumTestsExample.Framework.Elements
{
    /// <summary>
    /// Класс для работы с выпадающим списком.
    /// </summary>
    public class SelectElement
    {
        private readonly By _baseLocator;
        private readonly IWebDriver _driver;
        private readonly string _optionLocatorTemplate = "//option[contains(text(),'{0}')]";

        /// <summary>
        /// Создает новый экземпляр класса <see cref="SelectElement"/>.
        /// </summary>
        /// <param name="baseLocator"> Локатор базоваого длемента для списка.</param>
        /// <param name="driver"> WebDriver. </param>
        public SelectElement(By baseLocator, IWebDriver driver)
        {
            _baseLocator = baseLocator;
            _driver = driver;
        }

        /// <summary>
        /// Выбрать из списка отпицю по тексту.
        /// </summary>
        /// <param name="optionName"> Текст опции для выбора. </param>
        public void SelectByname(string optionName)
        {
            var baseElement = _driver.FindElement(_baseLocator);
            baseElement.Click();

            baseElement.FindElement(By.XPath(string.Format(_optionLocatorTemplate, optionName))).Click();
        }
    }
}