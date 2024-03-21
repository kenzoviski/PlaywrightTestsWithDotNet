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
            /*
            Given the URL
            When page is loaded
            Then fill username, password and click btnLogin
            */

            //Initialization
            BasePage basePage = new BasePage(Page);
            LoginPage loginPageInstance = new LoginPage(Page);
            await Page.GotoAsync(basePage.GetFullUrl("/login"));

            //Test steps
            await loginPageInstance.loginAction("test@test.com", "test");

        }
    }
}
