using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace TheInternetTests;

public abstract class BaseTest
{
    protected IWebDriver Driver;

    [SetUp]
    public virtual void Setup()
    {
        Driver = DriverFactory.Create();
    }

    [TearDown]
    public virtual void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            var path = Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            screenshot.SaveAsFile(path);
        }

        Driver?.Quit();
        Driver?.Dispose();
    }
}
