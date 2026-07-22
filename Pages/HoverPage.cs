using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TheInternetTests.Pages;

public class HoverPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    private static readonly By Avatars = By.CssSelector(".figure");
    private static readonly By HoverCaption = By.CssSelector(".figcaption h5");
    private static readonly By ViewProfileLink = By.CssSelector(".figcaption a");

    public HoverPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/hovers");
    }

    public void HoverOverAvatar(int index)
    {
        var avatars = wait.Until(d => {
            var els = d.FindElements(Avatars);
            return els.Count > index ? els : null;
        });
        new Actions(driver).MoveToElement(avatars[index]).Perform();
    }

    public string GetCaptionText(int index)
    {
        var captions = wait.Until(d => {
            var els = d.FindElements(HoverCaption);
            return els.Count > index ? els : null;
        });
        return captions[index].Text;
    }

    public bool IsViewProfileLinkVisible(int index)
    {
        var links = wait.Until(d => {
            var els = d.FindElements(ViewProfileLink);
            return els.Count > index ? els : null;
        });
        return links[index].Displayed;
    }
}
