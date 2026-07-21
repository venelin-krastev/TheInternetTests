using OpenQA.Selenium;
using TheInternetTests.Pages;

namespace TheInternetTests;

[TestFixture]
public class IFrameTests
{
    private IWebDriver driver;
    private IFramePage iframePage;

    [SetUp]
    public void Setup()
    {
        driver = DriverFactory.Create();
        iframePage = new IFramePage(driver);
    }

    [Test]
    public void IFrameContainsDefaultText()
    {
        iframePage.Open();
        iframePage.SwitchToIFrame();
        Assert.That(iframePage.GetEditorText(), Does.Contain("Your content goes here."));
    }

    [Test]
    public void CanSetTextInIFrame()
    {
        iframePage.Open();
        iframePage.SwitchToIFrame();
        iframePage.SetEditorText("Hello from Selenium");
        Assert.That(iframePage.GetEditorTextViaJs(), Does.Contain("Hello from Selenium"));
    }

    [Test]
    public void CanSwitchBackToMainPage()
    {
        iframePage.Open();
        iframePage.SwitchToIFrame();
        iframePage.SwitchToMainPage();
        Assert.That(driver.Title, Is.EqualTo("The Internet"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
