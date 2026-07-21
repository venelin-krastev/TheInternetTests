using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TheInternetTests.Pages;

public class AlertPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public AlertPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
    }

    public void TriggerAlert()
    {
        driver.FindElement(By.XPath("//button[text()='Click for JS Alert']")).Click();
    }

    public void TriggerConfirm()
    {
        driver.FindElement(By.XPath("//button[text()='Click for JS Confirm']")).Click();
    }

    public void TriggerPrompt()
    {
        driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']")).Click();
    }

    public string GetAlertText()
    {
        return wait.Until(d => d.SwitchTo().Alert().Text);
    }

    public void AcceptAlert()
    {
        wait.Until(d => d.SwitchTo().Alert()).Accept();
    }

    public void DismissAlert()
    {
        wait.Until(d => d.SwitchTo().Alert()).Dismiss();
    }

    public void TypeInPrompt(string text)
    {
        IAlert alert = wait.Until(d => d.SwitchTo().Alert());
        alert.SendKeys(text);
        alert.Accept();
    }

    public string GetResult()
    {
        return driver.FindElement(By.Id("result")).Text;
    }
}
