using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Hemz_QA_Mars.common
{
    public class Driver
    {
        public static IWebDriver driver;

        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        public void TearDown()
        {
            driver.Close();

        }
    }
}
