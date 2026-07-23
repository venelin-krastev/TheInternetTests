using TheInternetTests.Pages;

namespace TheInternetTests;

[TestFixture]
public class ContextMenuTests : BaseTest
{
    private ContextMenuPage contextMenuPage;

    [SetUp]
    public override void Setup()
    {
        base.Setup();
        contextMenuPage = new ContextMenuPage(Driver);
        contextMenuPage.Open();
    }

    [Test]
    public void RightClick_OpensAlert()
    {
        contextMenuPage.RightClickHotSpot();

        Assert.That(Driver.SwitchTo().Alert(), Is.Not.Null,
            "Right-clicking the hot spot should open a JS alert");

        Driver.SwitchTo().Alert().Accept();
    }

    [Test]
    public void RightClick_AlertContainsCorrectText()
    {
        contextMenuPage.RightClickHotSpot();

        Assert.That(contextMenuPage.GetAlertText(),
            Is.EqualTo("You selected a context menu"),
            "Alert text should confirm context menu selection");

        contextMenuPage.AcceptAlert();
    }

    [Test]
    public void RightClick_AlertCanBeDismissed()
    {
        contextMenuPage.RightClickHotSpot();
        contextMenuPage.AcceptAlert();

        Assert.That(Driver.Title, Is.EqualTo("The Internet"),
            "After dismissing alert, page should remain loaded");
    }
}
