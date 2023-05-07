using EaAppFramework.Config;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaAppFramework.Driver
{
    public class PlaywrightDriverInitializer
    {
        public const float DEFAULT_TIMEOUT = 30f;

        public async Task<IBrowser> GetChromiumDriverAsync(TestSettings testSettings )
        {
            var options = GetParameters(testSettings.Args, testSettings.Timeout, testSettings.Headless, testSettings.SlowMo);
            return await GetBrowserAsync(DriverType.Chromium, options);
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
