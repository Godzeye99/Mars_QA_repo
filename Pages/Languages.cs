using Hemz_QA_Mars.common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection.Emit;

namespace Hemz_QA_Mars.Pages
{
    public class Languages : Driver
    {
        //Tab Locator
        By languageTab = By.XPath("//a[@data-tab='first']");

        // Common Locators
        By languageField = By.XPath("//input[@placeholder='Add Language']");
        By levelDropdown = By.XPath("//select[@name='level']");
        By cancelButton = By.XPath("//input[@value='Cancel']");

        // Add Language Locators
        By addNewButton = By.XPath("//*[@data-tab='first']//*[text()='Add New']"); 
        By addButton = By.XPath("//input[@value='Add']");
        
        // Edit Language Locators
        By editIcon = By.XPath("//*[@data-tab='first']//*[@class='right aligned']//*[@class='outline write icon']");
        By updateButton = By.XPath("//input[@value='Update']");

        // Delete Language Locators
        By deleteIcon = By.XPath("//*[@data-tab='first']//*[@class='right aligned']//*[@class='remove icon']");

        //Success Message Locator
        By successMessage = By.XPath("//*[contains(@class, 'ns-type-success')]");


        // Interaction Methods
        public void select_language_tab()
        {
            IWebElement languageTabElement = driver.FindElement(languageTab);
            languageTabElement.Click();
        }

        public void click_add_new_language_button()
        {
            IWebElement addNewButtonElement = driver.FindElement(addNewButton);
            addNewButtonElement.Click();

        }
        public void enter_language(string Language)
        {
            IWebElement languageFieldElement = driver.FindElement(languageField);
            languageFieldElement.SendKeys(Language);

        }
        public void select_language_level(string Level)
        {
            IWebElement levelDropdownElement = driver.FindElement(levelDropdown);
            SelectElement selectedLevel = new SelectElement(levelDropdownElement);
            selectedLevel.SelectByValue(Level);
        }

        public void click_add_button()
        {
            IWebElement addButtonElement = driver.FindElement(addButton);
            addButtonElement.Click();
        }

        public void click_cancel_button()
        {
            IWebElement cancelButtonElement = driver.FindElement(cancelButton);
            cancelButtonElement.Click();
        }

        public void click_edit_icon()
        {
            IWebElement editIconElement = driver.FindElement(editIcon);
            editIconElement.Click();
        }

        public void click_update_button()
        {
            IWebElement updateButtonElement = driver.FindElement(updateButton);
            updateButtonElement.Click();
        }

        public void click_delete_icon()
        {
            IWebElement deleteIconElement = driver.FindElement(deleteIcon);
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

        public void update_language(string Language, String Level)
        {

            select_language_tab();
            click_edit_icon();
            enter_language(Language);
            select_language_level(Level);
            click_update_button();
        }

        public void delete_language()
        {
            select_language_tab();
            click_delete_icon();
        }


        // Verification methods
        public void verify_language_added_success_message()
        {

            IWebElement successMessageElement = driver.FindElement(successMessage);
            String actualText = successMessageElement.Text;
        }

        public void verify_language_updated_success_message()
        {

            IWebElement successMessageElement = driver.FindElement(successMessage);
            String actualText = successMessageElement.Text;

        }
        //Deleting Languages
        public void verify_language_deleted_success_message()
        {

            IWebElement successMessageElement = driver.FindElement(successMessage);
            String actualText = successMessageElement.Text;

        }

    }
}
