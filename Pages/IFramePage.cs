using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TheInternetTests.Pages;

public class IFramePage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public IFramePage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/iframe");
    }

    public void SwitchToIFrame()
    {
        IWebElement frame = wait.Until(d => d.FindElement(By.TagName("iframe")));
        driver.SwitchTo().Frame(frame);
    }

    public void SwitchToMainPage()
    {
        driver.SwitchTo().DefaultContent();
    }

    public string GetEditorText()
    {
        return driver.FindElement(By.CssSelector("body#tinymce")).Text;
    }

    public void SetEditorText(string text)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript($"document.querySelector('body#tinymce').innerHTML = '<p>{text}</p>';");
    }

    public string GetEditorTextViaJs()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        return js.ExecuteScript("return document.querySelector('body#tinymce').innerText;") as string ?? string.Empty;
    }
}
