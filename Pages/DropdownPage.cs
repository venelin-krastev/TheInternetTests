using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TheInternetTests.Pages;

public class DropdownPage
{
    private readonly IWebDriver driver;

    public DropdownPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");
    }

    public void SelectByText(string text)
    {
        var select = new SelectElement(driver.FindElement(By.Id("dropdown")));
        select.SelectByText(text);
    }

    public void SelectByValue(string value)
    {
        var select = new SelectElement(driver.FindElement(By.Id("dropdown")));
        select.SelectByValue(value);
    }

    public string GetSelectedOption()
    {
        var select = new SelectElement(driver.FindElement(By.Id("dropdown")));
        return select.SelectedOption.Text;
    }
}
