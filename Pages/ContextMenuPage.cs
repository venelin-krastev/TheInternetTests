using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TheInternetTests.Pages;

public class ContextMenuPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    private static readonly By HotSpot = By.Id("hot-spot");

    public ContextMenuPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open() => driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/context_menu");

    public void RightClickHotSpot()
    {
        var element = wait.Until(d => d.FindElement(HotSpot));
        new Actions(driver).ContextClick(element).Perform();
    }

    public string GetAlertText()
    {
        var alert = wait.Until(d => {
            try { return d.SwitchTo().Alert(); }
            catch (OpenQA.Selenium.NoAlertPresentException) { return null; }
        });
        return alert!.Text;
    }

    public void AcceptAlert()
    {
        driver.SwitchTo().Alert().Accept();
    }
}
