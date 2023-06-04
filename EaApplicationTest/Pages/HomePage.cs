using EaAppFramework.Driver;
using EaApplicationTest.Interfaces;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaApplicationTest.Pages
{
    public class HomePage : IHomePage
    {
        private readonly IPage page;

        private ILocator _registerLink => page.GetByRole(AriaRole.Link, new() { Name = "Register" });
        private ILocator _productLink => page.GetByRole(AriaRole.Link, new() { Name = "Product" });


        public HomePage(IPlaywrightDriver playwrightDriver) => this.page = playwrightDriver.Page;

        public async Task ClickRegisterLink() => await _registerLink.ClickAsync();
        public async Task ClickOnProductLink() => await _productLink.ClickAsync();


    }
}
