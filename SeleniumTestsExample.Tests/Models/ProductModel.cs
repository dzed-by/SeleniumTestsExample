namespace SeleniumTestsExample.Tests.Models
{
    /// <summary>
    /// Модель информации о продукте.
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Наименование продукта.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Описание продукта.
        /// </summary>
        public string Description { get; set; } 

        /// <summary>
        /// Цена продукта без валюты.
        /// </summary>
        public double Price { get; set; }
    }
}
