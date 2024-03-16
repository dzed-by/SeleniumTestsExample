using SeleniumTestsExample.Framework;
using SeleniumTestsExample.Tests.Pages;

namespace SeleniumTestsExample.Tests.Steps
{
    public class ProductsPageSteps
    {
        private readonly ProductsPage productsPage;

        public ProductsPageSteps(WebDriverProvider driverProvider)
        {
            productsPage = new ProductsPage(driverProvider.GetDriver());
        }

        public bool IsPageOpened()
        {
            return productsPage.IsOpened();
        }
    }
}
