using EaAppFramework.Config;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaAppFramework.Driver
{
    public class PlaywrightDriver:IDisposable
    {
        private readonly Task<IBrowser> _browser;
        private readonly Task<IPage> _page;
        private readonly TestSettings _testSettings;
        private readonly IPlaywrightDriverInitializer _playwrightDriverInitializer;
       
       
        public PlaywrightDriver( TestSettings testSettings, IPlaywrightDriverInitializer playwrightDriverInitializer)
        {
            _testSettings = testSettings;
            _playwrightDriverInitializer = playwrightDriverInitializer;
            _browser = Task.Run(InitializePlaywright);
            _page = Task.Run(CreatePageAsync);
            
        }
        public IPage Page => _page.Result;

       

        private async Task<IBrowser> InitializePlaywright()
        {
            return _testSettings.DriverType switch
            {
                DriverType.Chrome => await _playwrightDriverInitializer.GetChromeDriverAsync(_testSettings),
                DriverType.Firefox => await _playwrightDriverInitializer.GetFirefoxDriverAsync(_testSettings),
               _ => await _playwrightDriverInitializer.GetChromiumDriverAsync(_testSettings)
            }; 
        }

        private async Task<IPage> CreatePageAsync()
        {
            return await(await _browser).NewPageAsync();
        }

        public void  Dispose()
        {
           _browser?.Dispose();
        }
    }
}
