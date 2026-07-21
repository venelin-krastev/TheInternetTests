using TheInternetTests.Pages;

namespace TheInternetTests;

[TestFixture]
public class DragAndDropTests : BaseTest
{
    private DragAndDropPage dragAndDropPage;

    [SetUp]
    public override void Setup()
    {
        base.Setup();
        dragAndDropPage = new DragAndDropPage(Driver);
        dragAndDropPage.Open();
    }

    [Test]
    public void DragAOntoB_ColumnAHeaderChangesToB()
    {
        dragAndDropPage.DragAOntoB();

        Assert.That(dragAndDropPage.GetColumnAHeader(), Is.EqualTo("B"),
            "After drag, column A should display header 'B'");
    }

    [Test]
    public void DragAOntoB_ColumnBHeaderChangesToA()
    {
        dragAndDropPage.DragAOntoB();

        Assert.That(dragAndDropPage.GetColumnBHeader(), Is.EqualTo("A"),
            "After drag, column B should display header 'A'");
    }
}
