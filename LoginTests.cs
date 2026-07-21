using OpenQA.Selenium;
using TheInternetTests.Pages;

namespace TheInternetTests;

[TestFixture]
public class LoginTests
{
    private IWebDriver driver;
    private LoginPage loginPage;

    [SetUp]
    public void Setup()
    {
        driver = DriverFactory.Create();
        loginPage = new LoginPage(driver);
    }

    [Test]
    public void SuccessfulLoginRedirectsToSecurePage()
    {
        loginPage.Open();
        loginPage.Login("tomsmith", "SuperSecretPassword!");
        Assert.That(driver.Url, Does.Contain("/secure"));
    }

    [Test]
    public void SuccessfulLoginShowsSuccessMessage()
    {
        loginPage.Open();
        loginPage.Login("tomsmith", "SuperSecretPassword!");
        Assert.That(loginPage.GetFlashMessage(), Does.Contain("You logged into a secure area!"));
    }

    [Test]
    public void InvalidPasswordShowsErrorMessage()
    {
        loginPage.Open();
        loginPage.Login("tomsmith", "wrongpassword");
        Assert.That(loginPage.GetFlashMessage(), Does.Contain("Your password is invalid!"));
    }

    [Test]
    public void InvalidUsernameShowsErrorMessage()
    {
        loginPage.Open();
        loginPage.Login("wronguser", "SuperSecretPassword!");
        Assert.That(loginPage.GetFlashMessage(), Does.Contain("Your username is invalid!"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
