using Hemz_QA_Mars.common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Hemz_QA_Mars.Pages
{
    public class Skills : Driver
    {
        //Tab Locator
        By skillsTab = By.XPath("//a[@data-tab='second']");

        // Common Locators
        By skillField = By.XPath("//input[@placeholder='Add Skill']");
        By levelDropdown = By.XPath("//select[@name='level']");
        By cancelButton = By.XPath("//input[@value='Cancel']");

        // Add skills Locators
        By addNewButton = By.XPath("//*[@data-tab='second']//*[text()='Add New']");
        By addButton = By.XPath("//input[@value='Add']");

        // Edit skills Locators
        By editIcon = By.XPath("//*[@data-tab='second']//*[@class='right aligned']//*[@class='outline write icon']");
        By updateButton = By.XPath("//input[@value='Update']");

        // Delete skills Locators
        By deleteIcon = By.XPath("//*[@data-tab='second']//*[@class='right aligned']//*[@class='remove icon']");

        //Success Message Locator
        By successMessage = By.XPath("//*[contains(@class, 'ns-type-success')]");


        // Interaction Methods
        public void select_skills_tab()
        {
            IWebElement skillsTabElement = driver.FindElement(skillsTab);
            skillsTabElement.Click();
        }

        public void click_add_new_skills_button()
        {
            IWebElement addNewButtonElement = driver.FindElement(addNewButton);
            addNewButtonElement.Click();

        }
        public void enter_skills(string skills)
        {
            IWebElement skillsFieldElement = driver.FindElement(skillField);
            skillsFieldElement.SendKeys(skills);

        }
        public void select_skills_level(string Level)
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
        public void add_new_skills(string skill, string Level)
        {
            select_skills_tab();
            click_add_new_skills_button();
            enter_skills(skill);
            select_skills_level(Level);
            click_add_button();
        }

        public void update_skills(string skill, String Level)
        {

            select_skills_tab();
            click_edit_icon();
            enter_skills(skill);
            select_skills_level(Level);
            click_update_button();
        }

        public void delete_skills()
        {
            select_skills_tab();
            click_delete_icon();
        }


        // Verification methods
        public void verify_skills_added_success_message()
        {

            IWebElement successMessageElement = driver.FindElement(successMessage);
            String actualText = successMessageElement.Text;
        }

        public void verify_skills_updated_success_message()
        {

            IWebElement successMessageElement = driver.FindElement(successMessage);
            String actualText = successMessageElement.Text;

        }
        //Deleting Skills
        public void verify_skills_deleted_success_message()
        {

            IWebElement successMessageElement = driver.FindElement(successMessage);
            String actualText = successMessageElement.Text;

        }

    }
}
