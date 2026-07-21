using OpenQA.Selenium;
using TheInternetTests.Pages;

namespace TheInternetTests;

[TestFixture]
public class MultipleWindowsTests
{
    private IWebDriver driver;
    private MultipleWindowsPage windowsPage;

    [SetUp]
    public void Setup()
    {
        driver = DriverFactory.Create();
        windowsPage = new MultipleWindowsPage(driver);
    }

    [Test]
    public void ClickingLinkOpensNewWindow()
    {
        windowsPage.Open();
        windowsPage.ClickOpenNewWindow();
        Assert.That(windowsPage.GetWindowCount(), Is.EqualTo(2));
    }

    [Test]
    public void NewWindowHasCorrectTitle()
    {
        windowsPage.Open();
        windowsPage.ClickOpenNewWindow();
        windowsPage.SwitchToNewWindow();
        Assert.That(windowsPage.GetTitle(), Is.EqualTo("New Window"));
    }

    [Test]
    public void CanSwitchBackToMainWindow()
    {
        windowsPage.Open();
        windowsPage.ClickOpenNewWindow();
        windowsPage.SwitchToNewWindow();
        windowsPage.SwitchToMainWindow();
        Assert.That(windowsPage.GetTitle(), Is.EqualTo("The Internet"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
