using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_Mars_OnboardingTask.Drivers;
using SeleniumExtras.WaitHelpers;

namespace QA_Mars_OnboardingTask.Pages
{
    [Binding]
    public class LanguagesPage
    {
        private readonly IWebDriver driver;

        public LanguagesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Tab Locator
        IWebElement languageTabElement => driver.FindElement(By.XPath("//a[@data-tab='first']"));

        // Common Locators
        IWebElement languageField => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));

        IWebElement levelDropdown => driver.FindElement(By.XPath("//select[@name='level']"));
        IWebElement cancelButton => driver.FindElement(By.XPath("//input[@value='Cancel']"));

        // Add Language Locators
        IWebElement addNewButton => driver.FindElement(By.XPath("//*[@data-tab='first']//*[text()='Add New']"));
        IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));

        // Edit Language Locators
        IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));

        // Delete Language Locators

        //Success Message Locator
        IWebElement successMessage => driver.FindElement(By.XPath("//*[contains(@class, 'ns-type-success')]"));
        IWebElement errorMessage => driver.FindElement(By.XPath("//*[contains(@class, 'ns-type-error')]"));

        //Success message close
        IWebElement successMessageCloseButton => driver.FindElement(By.XPath("//*[@class='ns-close']"));


        // Interaction Methods
        public void select_language_tab()
        {
            languageTabElement.Click();
        }

        public void click_add_new_language_button()
        {
            addNewButton.Click();

        }
        public void enter_language(string Language)
        {
            languageField.Click();
            languageField.Clear();
            languageField.SendKeys(Language);

        }
        public void select_language_level(string Level)
        {
            SelectElement selectedLevel = new SelectElement(levelDropdown);
            selectedLevel.SelectByValue(Level);
        }

        public void click_add_button()
        {
            addButton.Click();
        }

        public void click_cancel_button()
        {
            cancelButton.Click();
        }

        public void click_edit_icon(string existingLanguage)
        {   
            IWebElement editIconElement = driver.FindElement(By.XPath("//*[@data-tab='first']//td[text()='" + existingLanguage + "']/following-sibling::*[@class='right aligned']//*[@class='outline write icon']"));
            editIconElement.Click();
        }

        public void click_update_button()
        {
            updateButton.Click();
        }

        public void click_delete_icon(string language)
        {
            IWebElement deleteIconElement = driver.FindElement(By.XPath("//*[@data-tab='first']//td[text()='" + language + "']/following-sibling::*[@class='right aligned']//*[@class='remove icon']"));
            deleteIconElement.Click();
        }

        // Workflow Methods
        public void add_new_language(string Language, string Level)
        {
            select_language_tab();
            click_add_new_language_button();
            enter_language(Language);
            select_language_level(Level);
            click_add_button();
        }

        public void update_language(string existingLanguage, string Language, String Level)
        {

            select_language_tab();
            click_edit_icon(existingLanguage);
            enter_language(Language);
            select_language_level(Level);
            click_update_button();
        }

        public void delete_language(string language)
        {
            select_language_tab();
            click_delete_icon(language);
        }

        public void delete_all_languages()
        {
            select_language_tab();
            var deleteIconsElementList = driver.FindElements(By.XPath("//*[@data-tab='first']//*[@class='right aligned']//*[@class='remove icon']"));
            for (int i = 0; i < deleteIconsElementList.Count; i++) { 
                deleteIconsElementList[i].Click();
                closeSuccessMessage();
            }
        }

        public void closeSuccessMessage()
        {
            successMessageCloseButton.Click();
            Thread.Sleep(1000);
        }


        // Verification methods
        public void verify_language_added_success_message(string message)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.TextToBePresentInElement(successMessage, message));
            Assert.AreEqual(successMessage.Text, message);
            closeSuccessMessage();
        }

        public void verify_language_updated_success_message(string message)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.TextToBePresentInElement(successMessage, message));
            Assert.AreEqual(successMessage.Text, message);
            closeSuccessMessage();

        }
        public void verify_language_deleted_success_message(string message)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.TextToBePresentInElement(successMessage, message));
            Assert.AreEqual(successMessage.Text, message);
            closeSuccessMessage();
        }
        public void verify_language_error_message(string message)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.TextToBePresentInElement(errorMessage, message));
            Assert.AreEqual(errorMessage.Text, message);
            closeSuccessMessage();
        }

    }
}
