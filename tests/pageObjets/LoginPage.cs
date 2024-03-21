using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace loginPage
{
    public class LoginPage : BasePage
    {

        //Locators
        private readonly ILocator _loginBtn;
        private readonly ILocator _userNameInput;
        private readonly ILocator _userPasswordInput;

        public LoginPage(IPage page) : base(page)
        {
            _loginBtn = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
            _userNameInput = Page.GetByLabel("Username *");
            _userPasswordInput = Page.GetByLabel("Password *");
        }

        //Methods
        public async Task loginAction(string username, string password)
        {
            await _userNameInput.FillAsync(username);
            await _userPasswordInput.FillAsync(password);
            await _loginBtn.ClickAsync();
        }
    }
}