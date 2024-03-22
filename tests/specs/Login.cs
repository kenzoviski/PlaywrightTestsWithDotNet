using Microsoft.Playwright.NUnit;
using loginPage;

namespace PlaywrightTests
{

    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
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

            #region Initialization
            BasePage basePageInstance = new BasePage(Page);
            LoginPage loginPageInstance = new LoginPage(Page);


            await Page.GotoAsync(basePageInstance.GetFullUrl("/login"));
            #endregion


            #region Test steps
            await loginPageInstance.assertElementsLoginPage();
            await loginPageInstance.loginAction("test@test.com", "test");
            await loginPageInstance.assertHomePageHeader();

            #endregion

        }
    }
}
