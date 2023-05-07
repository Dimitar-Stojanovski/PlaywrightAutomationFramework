using EaAppFramework.Config;
using EaAppFramework.Driver;
using Microsoft.Playwright;

namespace EaApplicationTest
{
    public class UnitTest1:IClassFixture<PlaywrightDriverInitializer>
    {
        private readonly PlaywrightDriverInitializer _playwrightDriverInitializer;
        private readonly PlaywrightDriver _playwrightDriver;

        public UnitTest1(PlaywrightDriverInitializer playwrightDriverInitializer)
        {
            var testSettings = new TestSettings()
            {
                DriverType=DriverType.Chromium,
                Headless=false,
                Timeout=15000,
                SlowMo = 500,
                ApplicationUrl = "http://eaapp.somee.com"
            };



            _playwrightDriverInitializer = playwrightDriverInitializer;
            _playwrightDriver = new PlaywrightDriver(testSettings, _playwrightDriverInitializer);
        }

        [Fact]
        public async Task Test1()
        {
            //PlaywrightDriver playwrightDriver = new PlaywrightDriver(); - this is abudnant know it is replaced with IclassFixture and the constructor


            var _page = _playwrightDriver.Page;

            await _page.GotoAsync("http://eaapp.somee.com");
            
            await _page.GetByRole(AriaRole.Link,new PageGetByRoleOptions() { Name="Login"}).ClickAsync();

            await _page.GetByLabel("UserName").FillAsync("admin");

            await _page.GetByLabel("Password").FillAsync("password");

            await _page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();

            await _page.GetByRole(AriaRole.Link, new() { Name = "Employee List" }).ClickAsync();
        }
    }
}