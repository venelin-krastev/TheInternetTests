using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TheInternetTests.Pages;

public class MultipleWindowsPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public MultipleWindowsPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
    }

    public void ClickOpenNewWindow()
    {
        driver.FindElement(By.LinkText("Click Here")).Click();
    }

    public void SwitchToNewWindow()
    {
        wait.Until(d => d.WindowHandles.Count >= 2);
        string newWindow = driver.WindowHandles.Last();
        driver.SwitchTo().Window(newWindow);
        wait.Until(d => d.Title.Length > 0);
    }

    public void SwitchToMainWindow()
    {
        string mainWindow = driver.WindowHandles.First();
        driver.SwitchTo().Window(mainWindow);
    }

    public string GetTitle()
    {
        return driver.Title;
    }

    public int GetWindowCount()
    {
        return driver.WindowHandles.Count;
    }
}
