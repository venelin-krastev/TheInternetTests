using OpenQA.Selenium;
using TheInternetTests.Pages;

namespace TheInternetTests;

[TestFixture]
public class FileUploadTests : BaseTest
{
    private FileUploadPage fileUploadPage;
    private string filePath;

    [SetUp]
    public override void Setup()
    {
        base.Setup();
        fileUploadPage = new FileUploadPage(Driver);
        filePath = Path.Combine(Path.GetTempPath(), "test-upload.txt");
        File.WriteAllText(filePath, "test content");
        fileUploadPage.Open();
    }

    [TearDown]
    public override void TearDown()
    {
        if (File.Exists(filePath))
            File.Delete(filePath);
        base.TearDown();
    }

    [Test]
    public void UploadFile_ShowsUploadedFileName()
    {
        fileUploadPage.UploadFile(filePath);

        Assert.That(fileUploadPage.GetUploadedFileName(), Does.Contain("test-upload.txt"),
            "Uploaded filename should appear on the page after upload");
    }

    [Test]
    public void UploadFile_ShowsSuccessHeader()
    {
        fileUploadPage.UploadFile(filePath);

        Assert.That(Driver.FindElement(By.CssSelector("h3")).Text, Is.EqualTo("File Uploaded!"),
            "Page should show 'File Uploaded!' header after successful upload");
    }
}
