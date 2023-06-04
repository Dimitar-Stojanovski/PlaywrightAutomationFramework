using Microsoft.Playwright;

namespace EaAppFramework.Driver
{
    public interface IPlaywrightDriver
    {
        IPage Page { get; }

        void Dispose();
        Task NavigateToUrl();
    }
}