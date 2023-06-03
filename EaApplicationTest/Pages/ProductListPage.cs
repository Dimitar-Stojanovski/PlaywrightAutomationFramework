using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace EaApplicationTest.Pages
{
    public class ProductListPage
    {
        private readonly IPage page;

        public ProductListPage(IPage page)
        {
            this.page = page;
        }

        private ILocator _createProductLink => page.GetByRole(AriaRole.Link, new() { Name = "Create" });
        private ILocator _verifyNameOfProduct => page.Locator("#Name");

        public async Task ClickCreateProductLink() => await _createProductLink.ClickAsync();

        public async Task ClickEditProductDetails(string _name)
        {
            await page.GetByRole(AriaRole.Row, new() { Name =_name })
                .GetByRole(AriaRole.Link, new() {Name="Details" }).ClickAsync();
        }

        public async Task<ILocator> VerifyProductName() => _verifyNameOfProduct;
       
        
       
    }
}
