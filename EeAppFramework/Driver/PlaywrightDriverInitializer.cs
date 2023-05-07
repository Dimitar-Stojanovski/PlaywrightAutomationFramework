using EaAppFramework.Config;
using Microsoft.Playwright;

namespace EaAppFramework.Driver
{
    public class PlaywrightDriverInitializer : IPlaywrightDriverInitializer
    {
        public const float DEFAULT_TIMEOUT = 30f;

        public async Task<IBrowser> GetChromiumDriverAsync(TestSettings testSettings)
        {
            var options = GetParameters(testSettings.Args, testSettings.Timeout, testSettings.Headless, testSettings.SlowMo);
            options.Channel = "chromium";
            return await GetBrowserAsync(DriverType.Chromium, options);
        }

        public async Task<IBrowser> GetChromeDriverAsync(TestSettings testSettings)
        {
            var options = GetParameters(testSettings.Args, testSettings.Timeout, testSettings.Headless, testSettings.SlowMo);
            options.Channel = "chrome";
            return await GetBrowserAsync(DriverType.Chromium, options);
        }

        public async Task<IBrowser> GetFirefoxDriverAsync(TestSettings testSettings)
        {
            var options = GetParameters(testSettings.Args, testSettings.Timeout, testSettings.Headless, testSettings.SlowMo);
            options.Channel = "firefox";
            return await GetBrowserAsync(DriverType.Firefox, options);
        }


        private async Task<IBrowser> GetBrowserAsync(DriverType driverType, BrowserTypeLaunchOptions options)
        {
            var playwright = await Playwright.CreateAsync();
            return await playwright[driverType.ToString().ToLower()].LaunchAsync(options);
        }



        private BrowserTypeLaunchOptions GetParameters(string[]? args, float? timeout = DEFAULT_TIMEOUT, bool? headless = true, float? slomo = null)
            => new()
            {
                Args = args,
                Timeout = ToMiliseconds(timeout),
                Headless = headless,
                SlowMo = slomo,
            };

        private static float? ToMiliseconds(float? seconds)
        {
            return seconds * 1000;
        }
    }
}
