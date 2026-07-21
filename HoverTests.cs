using TheInternetTests.Pages;

namespace TheInternetTests;

[TestFixture]
public class HoverTests : BaseTest
{
    private HoverPage hoverPage;

    [SetUp]
    public override void Setup()
    {
        base.Setup();
        hoverPage = new HoverPage(Driver);
        hoverPage.Open();
    }

    [Test]
    public void HoverOverFirstAvatar_ShowsUserOneCaptionText()
    {
        hoverPage.HoverOverAvatar(0);

        Assert.That(hoverPage.GetCaptionText(0), Does.Contain("user1"),
            "Hovering over first avatar should reveal caption with 'user1'");
    }

    [Test]
    public void HoverOverSecondAvatar_ShowsUserTwoCaptionText()
    {
        hoverPage.HoverOverAvatar(1);

        Assert.That(hoverPage.GetCaptionText(1), Does.Contain("user2"),
            "Hovering over second avatar should reveal caption with 'user2'");
    }

    [Test]
    public void HoverOverAvatar_MakesViewProfileLinkVisible()
    {
        hoverPage.HoverOverAvatar(0);

        Assert.That(hoverPage.IsViewProfileLinkVisible(0), Is.True,
            "View profile link should be visible after hovering over avatar");
    }

    [TestCase(0, "user1")]
    [TestCase(1, "user2")]
    [TestCase(2, "user3")]
    public void HoverOverAvatar_ShowsCorrectUsername(int index, string expectedUser)
    {
        hoverPage.HoverOverAvatar(index);

        Assert.That(hoverPage.GetCaptionText(index), Does.Contain(expectedUser),
            $"Hovering over avatar {index} should show caption for {expectedUser}");
    }
}
