using EaAppFramework.Driver;
using Microsoft.Playwright;

namespace EaApplicationTest
{
    public class UnitTest1:IClassFixture<PlaywrightDriver>
    {
        private readonly PlaywrightDriver playwrightDriver;

        public UnitTest1(PlaywrightDriver playwrightDriver)
        {
            this.playwrightDriver = playwrightDriver;
        }

        [Fact]
        public async Task Test1()
        {
            //PlaywrightDriver playwrightDriver = new PlaywrightDriver(); - this is abudnant know it is replaced with IclassFixture and the constructor


            var _page = playwrightDriver.Page;

            await _page.GotoAsync("http://eaapp.somee.com");
            
            await _page.GetByRole(AriaRole.Link,new PageGetByRoleOptions() { Name="Login"}).ClickAsync();

            await _page.GetByLabel("UserName").FillAsync("admin");

            await _page.GetByLabel("Password").FillAsync("password");

            await _page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();

            await _page.GetByRole(AriaRole.Link, new() { Name = "Employee List" }).ClickAsync();
        }
    }
}