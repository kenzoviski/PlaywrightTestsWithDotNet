using NUnit.Framework;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

public class BasePage
{
    protected readonly IPage Page;
    protected readonly PlaywrightTest Assert;
    protected static IPlaywright PlaywrightInstance;
    protected static IBrowser BrowserInstance;

    protected static string BaseUrl = "https://qa-automation-test-site.web.app";

    public BasePage(IPage page)
    {
        Page = page;
        Assert = new PlaywrightTest();
    }

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
        if (string.IsNullOrEmpty(relativeUrl))
        {
            return BaseUrl;
        }
        else
        {
            return $"{BaseUrl}{relativeUrl}";
        }
    }
}
