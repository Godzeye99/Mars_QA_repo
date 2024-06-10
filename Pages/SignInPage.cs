using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QA_Mars_OnboardingTask.Pages
{
    [Binding]
    public class SignInPage
    {
        private IWebDriver driver;

        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By signIn = By.LinkText("Sign In");
        By emailField = By.XPath("//input[contains(@name,'email')]");
        By passwordField = By.XPath("//input[contains(@name,'password')]");
        By loginButton = By.XPath("//button[contains(text(),'Login')]");

        // Interaction Methods
        public void click_sign_in()
        {
            IWebElement signInElement = driver.FindElement(signIn);
            signInElement.Click();
        }
        public void enter_email(String email)
        {
            IWebElement emailElement = driver.FindElement(emailField);
            emailElement.SendKeys(email);
        }

        public void enter_password(String password)
        {
            IWebElement passwordElement = driver.FindElement(passwordField);
            passwordElement.SendKeys(password);
        }

        public void click_login_button()
        {
            IWebElement loginElement = driver.FindElement(loginButton);
            loginElement.Click();
        }


        // Workflow
        public void login(String email, String password)
        {
            click_sign_in();
            enter_email(email);
            enter_password(password);
            click_login_button();
            Thread.Sleep(5000);
        }
    }
}