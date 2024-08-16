using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

using basePage;
using commonElements;

namespace checkBoxesPage
{
    public class CheckBoxesPage : BasePage
    {
        #region Locators

        public CheckBoxesPage(IPage page) : base(page)
        {
            // _login = Page.Locator("mat-card-title");
            // _userNameInput = Page.GetByLabel("Username *");
            // _userPasswordInput = Page.GetByLabel("Password *");
            // _loginBtn = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
            // _pageHeader = Page.GetByText("QA Automation Web");
        }

        #endregion

        #region Methods
        public async Task loginAction(string username, string password)
        {
            // await _userNameInput.FillAsync(username);
            // await _userPasswordInput.FillAsync(password);
            // await _loginBtn.ClickAsync();
        }


        public async Task assertElementsCheckBoxesPage()
        {
            // Pick locators for elements on CheckBoxes page and just assert if they're visible.
            //await ...
        }

        public async Task assertPageTitle() =>
            //Regex expression guarantees that the page title must be exactly "DockerJenkinsAngular"
            await Assert.Expect(Page).ToHaveTitleAsync(new Regex("^DockerJenkinsAngular$"));

        #endregion
    }
}