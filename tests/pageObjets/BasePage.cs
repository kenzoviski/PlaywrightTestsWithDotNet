using NUnit.Framework;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace basePage
{
    public class BasePage
    {
        #region Properties

        protected readonly IPage Page;
        protected readonly PlaywrightTest Assert;
        protected static IPlaywright PlaywrightInstance;
        protected static IBrowser BrowserInstance;

        protected static string BaseUrl = "https://qa-automation-test-site.web.app";

        #endregion

        #region Constructors
        /* Este construtor garante que o campo "Page" do objeto "BasePage" seja inicializado com o objeto "IPage"
        e que um novo objeto PlaywrightTest seja criado e associado ao campo Assert.
        */
        public BasePage(IPage page)
        {
            Page = page;
            Assert = new PlaywrightTest();
        }
        #endregion

        [SetUp]
        public void SetUp()
        {
            BrowserInstance = PlaywrightInstance.Chromium.LaunchAsync().GetAwaiter().GetResult();
            PlaywrightInstance = Playwright.CreateAsync().GetAwaiter().GetResult();
        }

        [TearDown]
        public void TearDown()
        {
            BrowserInstance?.DisposeAsync();
            PlaywrightInstance?.Dispose();
        }

        public string GetFullUrl(string relativeUrl = "")
        {
            return string.IsNullOrEmpty(relativeUrl) ? BaseUrl : $"{BaseUrl}{relativeUrl}";
        }
    }
}
