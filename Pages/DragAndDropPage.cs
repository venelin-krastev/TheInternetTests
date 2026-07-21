using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TheInternetTests.Pages;

public class DragAndDropPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    private static readonly By ElementA = By.Id("column-a");
    private static readonly By ElementB = By.Id("column-b");

    public DragAndDropPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/drag_and_drop");
    }

    public void DragAOntoB()
    {
        var source = wait.Until(d => d.FindElement(ElementA));
        var target = wait.Until(d => d.FindElement(ElementB));
        var actions = new Actions(driver);
        actions.DragAndDrop(source, target).Perform();
    }

    public string GetColumnAHeader()
    {
        return wait.Until(d => d.FindElement(ElementA)).Text;
    }

    public string GetColumnBHeader()
    {
        return wait.Until(d => d.FindElement(ElementB)).Text;
    }
}
