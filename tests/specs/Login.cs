using Microsoft.Playwright.NUnit;
using loginPage;

namespace PlaywrightTests
{

    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        #region Initialization
        /*Before each test, basePageInstance and loginPageInstance are instantiated.
        Also, it is guaranteed that before each test a new instance is created for browser and page.
        */
        private BasePage basePageInstance;
        private LoginPage loginPageInstance;

        [SetUp]
        public async Task SetUp()
        {
            basePageInstance = new BasePage(Page);
            loginPageInstance = new LoginPage(Page);
            await Page.GotoAsync(basePageInstance.GetFullUrl("/login"));
        }
        #endregion

        [Test]
        public async Task LoginPageElements()
        {
            #region Gherkin
            /*
            Given the URL
            When page is loaded
            Then assert all the elements are loaded/visible on the page
            */
            #endregion

            #region Test steps
            await loginPageInstance.assertElementsLoginPage();
            #endregion
        }

        [Test]
        public async Task LoginTest()
        {
            #region Gherkin
            /*
            Given the URL
            When page is loaded
            Then fill username, password and click btnLogin
            */
            #endregion

            #region Test steps
            await loginPageInstance.loginAction("test@test.com", "test");
            await loginPageInstance.assertHomePageHeader();
            await loginPageInstance.assertPageTitle();
            #endregion
        }
    }
}
