using Microsoft.Playwright.NUnit;
using loginPage;
using basePage;
using commonElements;

namespace PlaywrightTests
{

    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class CheckBoxes : PageTest
    {
        #region Initialization
        /*Before each test, basePageInstance and loginPageInstance are instantiated.
        Also, it is guaranteed that before each test a new instance is created for browser and page.
        */
        private BasePage basePageInstance;
        private LoginPage loginPageInstance;
        private CommonElements commonElementsInstance;

        [SetUp]
        public async Task SetUp()
        {
            string username = "test@test.com";
            string password = "test";

            basePageInstance = new BasePage(Page);
            loginPageInstance = new LoginPage(Page);
            commonElementsInstance = new CommonElements(Page);

            await Page.GotoAsync(basePageInstance.GetFullUrl("/login"));
            await loginPageInstance.loginAction(username, password);

            // Navigate to "Check-boxes" menu item
            await commonElementsInstance.navigateToMenu(CommonElements.MenuLocator.CheckBoxes);
        }
        #endregion

        [Test, Order(1)]
        public async Task CheckBoxesElements()
        {
            #region Gherkin
            /*
            Given the URL: https://qa-automation-test-site.web.app/home
            When page is loaded
            Then assert all the elements are loaded/visible on the page
            */
            #endregion

            #region Test steps
            //await loginPageInstance.assertElementsCheckBoxesPage();
            #endregion
        }
    }
}
