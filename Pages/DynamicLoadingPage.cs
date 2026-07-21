using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TheInternetTests.Pages;

public class DynamicLoadingPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public DynamicLoadingPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
    }

    public void Open(int example)
    {
        driver.Navigate().GoToUrl($"https://the-internet.herokuapp.com/dynamic_loading/{example}");
    }

    public void ClickStart()
    {
        driver.FindElement(By.CssSelector("#start button")).Click();
    }

    public string GetFinishText()
    {
        return wait.Until(d =>
        {
            var el = d.FindElement(By.CssSelector("#finish h4"));
            return el.Displayed ? el.Text : null;
        });
    }
}
