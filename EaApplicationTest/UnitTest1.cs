using AutoFixture.Xunit2;
using EaAppFramework.Config;
using EaAppFramework.Driver;
using EaApplicationTest.Models;
using EaApplicationTest.Pages;
using Microsoft.Playwright;

namespace EaApplicationTest
{
    public class UnitTest1:IClassFixture<PlaywrightDriverInitializer>
    {
        private readonly PlaywrightDriverInitializer _playwrightDriverInitializer;
        private readonly PlaywrightDriver _playwrightDriver;
        private readonly TestSettings _testSettings;

        public UnitTest1(PlaywrightDriverInitializer playwrightDriverInitializer)
        {
            _testSettings = ConfigReader.ReadConfig();
            _playwrightDriverInitializer = playwrightDriverInitializer;
            _playwrightDriver = new PlaywrightDriver(_testSettings, _playwrightDriverInitializer);
        }

       /* [Fact]
        public async Task Test1()
        {
            //PlaywrightDriver playwrightDriver = new PlaywrightDriver(); - this is abudnant know it is replaced with IclassFixture and the constructor


            var _page = _playwrightDriver.Page;

            await _page.GotoAsync(_testSettings.ApplicationUrl);
            
            await _page.GetByRole(AriaRole.Link,new PageGetByRoleOptions() { Name="Login"}).ClickAsync();

            await _page.GetByLabel("UserName").FillAsync("admin");

            await _page.GetByLabel("Password").FillAsync("password");

            await _page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();

            await _page.GetByRole(AriaRole.Link, new() { Name = "Employee List" }).ClickAsync();
        }*/

       /* [Fact]
        public async Task test2()
        {
            var page = _playwrightDriver.Page;
            await page.GotoAsync(_testSettings.ApplicationUrl);
            HomePage homePage = new HomePage(page);
           await  homePage.ClickRegisterLink();


            RegisterPage registerPage = new RegisterPage(page);
           await registerPage.EnterUserName("User 123");
           await registerPage.EnterPassword("password");
           await  registerPage.EnterConfirmPass("pass");
           await registerPage.EnterEmail("email");
           await registerPage.ClickRegisterBtn();
                
                
                
            

        }*/

        [Fact]
        public async Task RegisterProduct()
        {
            var _page = _playwrightDriver.Page;
            await _page.GotoAsync(_testSettings.ApplicationUrl);
            var homePage = new HomePage(_page);
            await homePage.ClickOnProductLink();

            var productListPage = new ProductListPage(_page);
            productListPage.ClickCreateProductLink();

            var productPage = new ProductPage(_page);
            await productPage.CreateProduct("Dimitar Product", "Test description",2000, "2");
            await productPage.ClickCreateBtn();
            await productListPage.ClickEditProductDetails("Dimitar Product");

            //Assert
            await Assertions.Expect(productListPage.VerifyProductName().Result).ToHaveTextAsync("Dimitar Product");
            Thread.Sleep(3000);

           
        }

        [Theory]
        [InlineData("Dimitar Speaker1", "Test Speaker1", 200, "3")]
        [InlineData("Dimitar Speaker2", "Test Speaker2", 300, "3")]
        [InlineData("Dimitar Speaker3", "Test Speaker3", 400, "2")]
        [InlineData("Dimitar Speaker4", "Test Speaker4", 500, "1")]
        public async Task RegisterProductWithData(string productName, string description, decimal productPrice, string productOption)
        {
            var _page = _playwrightDriver.Page;
            await _page.GotoAsync(_testSettings.ApplicationUrl);
            var homePage = new HomePage(_page);
            await homePage.ClickOnProductLink();

            var productListPage = new ProductListPage(_page);
            productListPage.ClickCreateProductLink();

            var productPage = new ProductPage(_page);
            await productPage.CreateProduct(productName, description, productPrice, productOption);
            await productPage.ClickCreateBtn();
            await productListPage.ClickEditProductDetails(productName);

            //Assert
            await Assertions.Expect(productListPage.VerifyProductName().Result).ToHaveTextAsync(productName);
            


        }


        [Fact]
        public async Task RegisterProductWithConcreteData()
        {
            var _page = _playwrightDriver.Page;


            await _page.GotoAsync(_testSettings.ApplicationUrl);
            var homePage = new HomePage(_page);
            await homePage.ClickOnProductLink();

            var productListPage = new ProductListPage(_page);
            productListPage.ClickCreateProductLink();



            //Creating the product
            var product = new ProductDto()
            {
                Name = "Test Product",
                Description = "Description",
                Price = 1000,
                productType = ProductType.CPU
            };

            var productPage = new ProductPage(_page);
            await productPage.CreateProduct(product);
            await productPage.ClickCreateBtn();
            await productListPage.ClickEditProductDetails(product.Name);

            //Assert
            await Assertions.Expect(productListPage.VerifyProductName().Result).ToHaveTextAsync(product.Name);



        }


        [Theory,AutoData]
        public async Task RegisterWithAutoFixtureData(ProductDto product)
        {
            var _page = _playwrightDriver.Page;


            //await _page.GotoAsync(_testSettings.ApplicationUrl);
            var homePage = new HomePage(_page);
            await homePage.ClickOnProductLink();

            var productListPage = new ProductListPage(_page);
            productListPage.ClickCreateProductLink();



            //Auto Data will insert random Data
           /* var product = new ProductDto()
            {
                Name = "Test Product",
                Description = "Description",
                Price = 1000,
                productType = ProductType.CPU
            };*/

            var productPage = new ProductPage(_page);
            await productPage.CreateProduct(product);
            await productPage.ClickCreateBtn();
            await productListPage.ClickEditProductDetails(product.Name);

            //Assert
            await Assertions.Expect(productListPage.VerifyProductName().Result).ToHaveTextAsync(product.Name);



        }


    }
}