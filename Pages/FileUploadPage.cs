using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TheInternetTests.Pages;

public class FileUploadPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    private static readonly By FileInput = By.Id("file-upload");
    private static readonly By UploadButton = By.Id("file-submit");
    private static readonly By UploadedFileName = By.Id("uploaded-files");

    public FileUploadPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");
    }

    public void UploadFile(string filePath)
    {
        wait.Until(d => d.FindElement(FileInput)).SendKeys(filePath);
        wait.Until(d => d.FindElement(UploadButton)).Click();
    }

    public string GetUploadedFileName()
    {
        return wait.Until(d => d.FindElement(UploadedFileName)).Text;
    }
}
