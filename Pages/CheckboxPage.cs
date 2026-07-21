using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TheInternetTests.Pages;

public class CheckboxPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public CheckboxPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
    }

    public bool IsChecked(int index)
    {
        var checkboxes = wait.Until(d =>
        {
            var els = d.FindElements(By.CssSelector("input[type='checkbox']"));
            return els.Count >= 2 ? els : null;
        });
        return checkboxes[index].Selected;
    }

    public void Toggle(int index)
    {
        var checkboxes = wait.Until(d =>
        {
            var els = d.FindElements(By.CssSelector("input[type='checkbox']"));
            return els.Count >= 2 ? els : null;
        });
        checkboxes[index].Click();
    }
}
