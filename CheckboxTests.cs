using OpenQA.Selenium;
using TheInternetTests.Pages;

namespace TheInternetTests;

[TestFixture]
public class CheckboxTests
{
    private IWebDriver driver;
    private CheckboxPage checkboxPage;

    [SetUp]
    public void Setup()
    {
        driver = DriverFactory.Create();
        checkboxPage = new CheckboxPage(driver);
    }

    [Test]
    public void FirstCheckboxIsUncheckedByDefault()
    {
        checkboxPage.Open();
        Assert.That(checkboxPage.IsChecked(0), Is.False);
    }

    [Test]
    public void SecondCheckboxIsCheckedByDefault()
    {
        checkboxPage.Open();
        Assert.That(checkboxPage.IsChecked(1), Is.True);
    }

    [Test]
    public void CanCheckFirstCheckbox()
    {
        checkboxPage.Open();
        checkboxPage.Toggle(0);
        Assert.That(checkboxPage.IsChecked(0), Is.True);
    }

    [Test]
    public void CanUncheckSecondCheckbox()
    {
        checkboxPage.Open();
        checkboxPage.Toggle(1);
        Assert.That(checkboxPage.IsChecked(1), Is.False);
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
