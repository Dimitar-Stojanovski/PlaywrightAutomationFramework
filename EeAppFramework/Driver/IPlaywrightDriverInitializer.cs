using EaAppFramework.Config;
using Microsoft.Playwright;

namespace EaAppFramework.Driver
{
    public interface IPlaywrightDriverInitializer
    {
        Task<IBrowser> GetChromiumDriverAsync(TestSettings testSettings);
        Task<IBrowser> GetFirefoxDriverAsync(TestSettings testSettings);
        Task<IBrowser> GetChromeDriverAsync(TestSettings testSettings);
    }
}