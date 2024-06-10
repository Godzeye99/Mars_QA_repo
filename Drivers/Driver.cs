using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace QA_Mars_OnboardingTask.Drivers
{
    public class Driver
    {
        private IWebDriver driver;
        public IWebDriver Initialize() {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(" http://localhost:5000/ ");
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return this.driver;
        }
    }
}
