using OpenQA.Selenium;
using TheInternetTests.Pages;

namespace TheInternetTests;

[TestFixture]
public class AlertTests
{
    private IWebDriver driver;
    private AlertPage alertPage;

    [SetUp]
    public void Setup()
    {
        driver = DriverFactory.Create();
        alertPage = new AlertPage(driver);
    }

    [Test]
    public void AlertShowsCorrectText()
    {
        alertPage.Open();
        alertPage.TriggerAlert();
        Assert.That(alertPage.GetAlertText(), Is.EqualTo("I am a JS Alert"));
    }

    [Test]
    public void AcceptingAlertShowsResult()
    {
        alertPage.Open();
        alertPage.TriggerAlert();
        alertPage.AcceptAlert();
        Assert.That(alertPage.GetResult(), Is.EqualTo("You successfully clicked an alert"));
    }

    [Test]
    public void AcceptingConfirmShowsResult()
    {
        alertPage.Open();
        alertPage.TriggerConfirm();
        alertPage.AcceptAlert();
        Assert.That(alertPage.GetResult(), Is.EqualTo("You clicked: Ok"));
    }

    [Test]
    public void DismissingConfirmShowsResult()
    {
        alertPage.Open();
        alertPage.TriggerConfirm();
        alertPage.DismissAlert();
        Assert.That(alertPage.GetResult(), Is.EqualTo("You clicked: Cancel"));
    }

    [Test]
    public void PromptAcceptsTypedText()
    {
        alertPage.Open();
        alertPage.TriggerPrompt();
        alertPage.TypeInPrompt("Selenium");
        Assert.That(alertPage.GetResult(), Is.EqualTo("You entered: Selenium"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
