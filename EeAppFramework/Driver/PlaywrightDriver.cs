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
        private readonly Task<IPage> _page;
        private readonly TestSettings testSettings;
        private IBrowser? _browser;
        public PlaywrightDriver( TestSettings testSettings)
        {
            // have to do with Task Run because the method is async
            _page = Task.Run(InitializePlaywright);
            this.testSettings = testSettings;
        }
        public IPage Page => _page.Result;

       

        public async Task<IPage> InitializePlaywright()
        {
           

            return await _browser.NewPageAsync();
        }

        public void  Dispose()
        {
           _browser?.DisposeAsync();
        }
    }
}
