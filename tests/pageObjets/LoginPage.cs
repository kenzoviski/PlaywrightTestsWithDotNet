using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace loginPage
{
    public class LoginPage : BasePage
    {

        #region Locators
        private readonly ILocator _login;
        private readonly ILocator _userNameInput;
        private readonly ILocator _userPasswordInput;
        private readonly ILocator _loginBtn;
        private readonly ILocator _pageHeader;

        public LoginPage(IPage page) : base(page)
        {

            _login = Page.Locator("mat-card-title");
            _userNameInput = Page.GetByLabel("Username *");
            _userPasswordInput = Page.GetByLabel("Password *");
            _loginBtn = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
            _pageHeader = Page.GetByText("QA Automation Web");
        }

        #endregion

        #region Methods
        public async Task loginAction(string username, string password)
        {
            await _userNameInput.FillAsync(username);
            await _userPasswordInput.FillAsync(password);
            await _loginBtn.ClickAsync();
        }


        public async Task assertElementsLoginPage()
        {
            await Assert.Expect(_login).ToBeVisibleAsync();
            await Assert.Expect(_userNameInput).ToBeVisibleAsync();
            await Assert.Expect(_userPasswordInput).ToBeVisibleAsync();
            await Assert.Expect(_loginBtn).ToBeVisibleAsync();
        }

        public async Task assertHomePageHeader()
        {
            //Regex expression guarantees that the page header must be exactly "QA Automation Web"
            await Assert.Expect(_pageHeader).ToHaveTextAsync(new Regex("^QA Automation Web$"));
        }

        public async Task assertPageTitle()
        {
            //Regex expression guarantees that the page title must be exactly "DockerJenkinsAngular"
            await Assert.Expect(Page).ToHaveTitleAsync(new Regex("^DockerJenkinsAngular$"));
        }

        #endregion
    }
}