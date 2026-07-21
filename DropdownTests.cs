using OpenQA.Selenium;
using TheInternetTests.Pages;

namespace TheInternetTests;

[TestFixture]
public class DropdownTests
{
    private IWebDriver driver;
    private DropdownPage dropdownPage;

    [SetUp]
    public void Setup()
    {
        driver = DriverFactory.Create();
        dropdownPage = new DropdownPage(driver);
    }

    [Test]
    public void SelectOptionOneByText()
    {
        dropdownPage.Open();
        dropdownPage.SelectByText("Option 1");
        Assert.That(dropdownPage.GetSelectedOption(), Is.EqualTo("Option 1"));
    }

    [Test]
    public void SelectOptionTwoByValue()
    {
        dropdownPage.Open();
        dropdownPage.SelectByValue("2");
        Assert.That(dropdownPage.GetSelectedOption(), Is.EqualTo("Option 2"));
    }

    [TestCase("Option 1")]
    [TestCase("Option 2")]
    public void CanSelectOption(string option)
    {
        dropdownPage.Open();
        dropdownPage.SelectByText(option);
        Assert.That(dropdownPage.GetSelectedOption(), Is.EqualTo(option));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
