using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

using basePage;

namespace commonElements
{
    public class CommonElements : BasePage
    {
        #region Locators
        private ILocator _pageHeader;
        private ILocator _home;
        private ILocator _checkBoxes;
        private ILocator _inputFields;
        private ILocator _dropDowns;
        private ILocator _radioButtons;
        private ILocator _table;
        private ILocator _toggles;
        private ILocator _datePickers;
        private ILocator _e2eScenario;
        private ILocator _admin;
        private ILocator _menuMessage;

        public CommonElements(IPage page) : base(page)
        {
            // Menu buttons
            _home = Page.GetByRole(AriaRole.Link, new() { Name = "Home" });
            _checkBoxes = Page.GetByRole(AriaRole.Link, new() { Name = "Check-boxes" });
            _inputFields = Page.GetByRole(AriaRole.Link, new() { Name = "Input fields" });
            _dropDowns = Page.GetByRole(AriaRole.Link, new() { Name = "Drop-downs" });
            _radioButtons = Page.GetByRole(AriaRole.Link, new() { Name = "Radio-buttons" });
            _table = Page.GetByRole(AriaRole.Link, new() { Name = "Table" });
            _toggles = Page.GetByRole(AriaRole.Link, new() { Name = "Toggles" });
            _datePickers = Page.GetByRole(AriaRole.Link, new() { Name = "Date pickers" });
            _e2eScenario = Page.GetByRole(AriaRole.Link, new() { Name = "E2E scenario" });
            _admin = Page.GetByRole(AriaRole.Button, new() { Name = "admin" });

            // Other elements
            _pageHeader = Page.GetByText("QA Automation Web");
            _menuMessage = Page.GetByText("Simple website designed for");

        }

        public enum MenuLocator
        {
            Home, CheckBoxes, InputFields, DropDowns, RadioButtons,
            Table, Toggles, DatePickers, E2EScenario, Admin
        }

        #endregion

        #region Methods
        public async Task navigateToMenu(MenuLocator menu)
        {
            switch (menu)
            {
                case MenuLocator.Home:
                    await _home.ClickAsync();
                    break;
                case MenuLocator.CheckBoxes:
                    await _checkBoxes.ClickAsync();
                    break;
                case MenuLocator.InputFields:
                    await _inputFields.ClickAsync();
                    break;
                case MenuLocator.DropDowns:
                    await _dropDowns.ClickAsync();
                    break;
                case MenuLocator.RadioButtons:
                    await _radioButtons.ClickAsync();
                    break;
                case MenuLocator.Table:
                    await _table.ClickAsync();
                    break;
                case MenuLocator.Toggles:
                    await _toggles.ClickAsync();
                    break;
                case MenuLocator.DatePickers:
                    await _datePickers.ClickAsync();
                    break;
                case MenuLocator.E2EScenario:
                    await _e2eScenario.ClickAsync();
                    break;
                case MenuLocator.Admin:
                    await _admin.ClickAsync();
                    break;
                default:
                    throw new ArgumentException($"Invalid menu locator: {menu}");
            }
        }

        public async Task assertHomePageHeader() =>
            //Regex expression guarantees that the page header must be exactly "QA Automation Web"
            await Assert.Expect(_pageHeader).ToHaveTextAsync(new Regex("^QA Automation Web$"));

        public async Task assertPageTitle() =>
            //Regex expression guarantees that the page title must be exactly "DockerJenkinsAngular"
            await Assert.Expect(Page).ToHaveTitleAsync(new Regex("^DockerJenkinsAngular$"));

        #endregion
    }
}