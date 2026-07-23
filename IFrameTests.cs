using TheInternetTests.Pages;

namespace TheInternetTests;

[TestFixture]
public class IFrameTests : BaseTest
{
    private IFramePage iframePage;

    [SetUp]
    public override void Setup()
    {
        base.Setup();
        iframePage = new IFramePage(Driver);
    }

    [Test]
    public void IFrameContainsDefaultText()
    {
        iframePage.Open();
        iframePage.SwitchToIFrame();
        Assert.That(iframePage.GetEditorText(), Does.Contain("Your content goes here."),
            "TinyMCE editor should load with default content");
    }

    [Test]
    public void CanSetTextInIFrame()
    {
        iframePage.Open();
        iframePage.SwitchToIFrame();
        iframePage.SetEditorText("Hello from Selenium");
        Assert.That(iframePage.GetEditorTextViaJs(), Does.Contain("Hello from Selenium"),
            "Editor text should reflect what was set via JavaScript");
    }

    [Test]
    public void CanSwitchBackToMainPage()
    {
        iframePage.Open();
        iframePage.SwitchToIFrame();
        iframePage.SwitchToMainPage();
        Assert.That(Driver.Title, Is.EqualTo("The Internet"),
            "After switching back, driver context should be on main page");
    }
}
