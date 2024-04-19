using Hemz_QA_Mars.common;
using OpenQA.Selenium;

namespace Hemz_QA_Mars.Pages
{
    public class SignIn : Driver
    {
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
            emailElement.Click();
        }

        public void enter_password(String password)
        {
            IWebElement passwordElement = driver.FindElement(passwordField);
            passwordElement.Click();
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
