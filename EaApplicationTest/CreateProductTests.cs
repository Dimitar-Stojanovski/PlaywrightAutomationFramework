using AutoFixture.Xunit2;
using EaAppFramework.Config;
using EaAppFramework.Driver;
using EaApplicationTest.Interfaces;
using EaApplicationTest.Models;
using EaApplicationTest.Pages;
using Microsoft.Playwright;

namespace EaApplicationTest
{
    public class CreateProductTests
    {
        private readonly IPlaywrightDriver _playwrightDriver;
        private readonly IHomePage homePage;
        private readonly IProductListPage productListPage;
        private readonly IProductPage productPage;

        public CreateProductTests(IPlaywrightDriver playwrightDriver,IHomePage homePage,IProductListPage productListPage,IProductPage productPage)
        {
            _playwrightDriver = playwrightDriver;
            this.homePage = homePage;
            this.productListPage = productListPage;
            this.productPage = productPage;
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
            
            await homePage.ClickOnProductLink();
            await productListPage.ClickCreateProductLink();

            await productPage.CreateProduct("Dimitar Product", "Test description", 2000, "2");
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
            await homePage.ClickOnProductLink();
            await productListPage.ClickCreateProductLink();

            await productPage.CreateProduct(productName, description, productPrice, productOption);
            await productPage.ClickCreateBtn();
            await productListPage.ClickEditProductDetails(productName);

            //Assert
            await Assertions.Expect(productListPage.VerifyProductName().Result).ToHaveTextAsync(productName);



        }


        [Fact]
        public async Task RegisterProductWithConcreteData()
        {
            
            await homePage.ClickOnProductLink();
            await productListPage.ClickCreateProductLink();
            var product = new ProductDto()
            {
                Name = "Test Product",
                Description = "Description",
                Price = 1000,
                productType = ProductType.CPU
            };

           
            await productPage.CreateProduct(product);
            await productPage.ClickCreateBtn();
            await productListPage.ClickEditProductDetails(product.Name);

            //Assert
            await Assertions.Expect(productListPage.VerifyProductName().Result).ToHaveTextAsync(product.Name);



        }


        [Theory, AutoData]
        public async Task RegisterWithAutoFixtureData(ProductDto product)
        {
            await homePage.ClickOnProductLink();
            await productListPage.ClickCreateProductLink();
            await productPage.CreateProduct(product);
            await productPage.ClickCreateBtn();
            await productListPage.ClickEditProductDetails(product.Name);

            //Assert
            await Assertions.Expect(productListPage.VerifyProductName().Result).ToHaveTextAsync(product.Name);



        }



    }
}