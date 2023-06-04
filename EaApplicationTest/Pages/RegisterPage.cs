using EaAppFramework.Driver;
using EaApplicationTest.Interfaces;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaApplicationTest.Pages
{
    public class RegisterPage : IRegisterPage
    {
        private readonly IPage page;

        private ILocator userNameInput => page.GetByLabel("UserName");
        private ILocator passwordInput => page.GetByLabel("Password", new() { Exact = true });
        private ILocator confirmPassword => page.GetByLabel("Confirm password");
        private ILocator emailInput => page.GetByLabel("Email");
        private ILocator registerButton => page.GetByRole(AriaRole.Button, new() { Name = "Register" });

        public RegisterPage(PlaywrightDriver playwrightDriver) => this.page = playwrightDriver.Page;

        public async Task EnterUserName(string userName) => await userNameInput.FillAsync(userName);
        public async Task EnterPassword(string password) => await passwordInput.FillAsync(password);
        public async Task EnterConfirmPass(string password) => await confirmPassword.FillAsync(password);
        public async Task EnterEmail(string email) => await emailInput.FillAsync(email);
        public async Task ClickRegisterBtn() => await registerButton.ClickAsync();

    }
}
