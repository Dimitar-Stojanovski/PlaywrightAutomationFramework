using EaApplicationTest.Models;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaApplicationTest.Pages
{
    public class ProductPage
    {
        private readonly IPage page;
        public ProductPage(IPage page)
        {
            this.page = page;
        }

        private ILocator createLink => page.GetByRole(AriaRole.Link, new() { Name = "Create" });
        private ILocator _nameField => page.GetByLabel("Name");
        private ILocator _descriptionField => page.GetByLabel("Description");
        private ILocator _priceField => page.Locator("#Price");
        private ILocator _selectProduct => page.GetByRole(AriaRole.Combobox, new() { Name = "ProductType" });
        private ILocator _createBtn => page.GetByRole(AriaRole.Button, new() { Name = "Create" });


        public async Task CreateProduct(string name, string description, decimal price,string productType)
        {
            await _nameField.FillAsync(name);
            await _descriptionField.FillAsync(description);
            await _priceField.FillAsync(price.ToString());
            await _selectProduct.SelectOptionAsync(productType);
        }

        public async Task ClickCreateBtn()=> await _createBtn.ClickAsync();

        public async Task CreateProduct(ProductDto product)
        {
            await _nameField.FillAsync(product.Name);
            await _descriptionField.FillAsync(product.Description);
            await _priceField.FillAsync(product.Price.ToString());
            await _selectProduct.SelectOptionAsync(product.productType.ToString());
        }


    }
}
