using System.Text.RegularExpressions;

namespace SeleniumTestsExample.Framework.Utils
{
    /// <summary>
    /// Класс расширений для строк.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Получить цену в виде строки без валюты. Если строка не содердит цену - вернет пустую строку.
        /// </summary>
        /// <param name="priceWithCurrency"> Цена с валютой. </param>
        /// <returns> Цена без валюты в виде строки.Или пустая строка, если она не содержит цену. </returns>
        public static string GetPriceWithoutCurrency(this string priceWithCurrency)
        {
            Regex regex = new Regex(@"(-?\d+\.?\d*)");
            if (regex.IsMatch(priceWithCurrency))
            {
                return regex.Match(priceWithCurrency).Value.Replace('.', ',');
            }
            
            return string.Empty;
        }
    }
}
