using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace QA_Mars_OnboardingTask.Pages
{
    [Binding]
    public class SkillsPage
    {
        private IWebDriver driver;

        public SkillsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Tab Locator
        IWebElement skillsTab => driver.FindElement(By.XPath("//a[@data-tab='second']"));

        // Common Locators
        IWebElement skillField => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        IWebElement levelDropdown => driver.FindElement(By.XPath("//select[@name='level']"));
        IWebElement cancelButton => driver.FindElement(By.XPath("//input[@value='Cancel']"));

        // Add skills Locators
        IWebElement addNewButton => driver.FindElement(By.XPath("//*[@data-tab='second']//*[text()='Add New']"));
        IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));

        // Edit skills Locators
        IWebElement editIcon => driver.FindElement(By.XPath("//*[@data-tab='second']//*[@class='right aligned']//*[@class='outline write icon']"));
        IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));

        // Delete skills Locators

        //Success Message Locator
        IWebElement successMessage => driver.FindElement(By.XPath("//*[contains(@class, 'ns-type-success')]"));
        IWebElement errorMessage => driver.FindElement(By.XPath("//*[contains(@class, 'ns-type-error')]"));

        //Success Message Close
        IWebElement successMessageCloseButton => driver.FindElement(By.XPath("//*[@class='ns-close']"));


        // Interaction Methods
        public void select_skills_tab()
        {
            skillsTab.Click();
        }

        public void click_add_new_skills_button()
        {
            addNewButton.Click();

        }
        public void enter_skills(string skills)
        {
            skillField.Click();
            skillField.Clear();
            skillField.SendKeys(skills);
        }
        public void select_skills_level(string Level)
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

        public void click_edit_icon(string existingSkill)
        {
            IWebElement editIconElement = driver.FindElement(By.XPath("//*[@data-tab='second']//td[text()='" + existingSkill + "']/following-sibling::*[@class='right aligned']//*[@class='outline write icon']"));
            editIconElement.Click();
        }

        public void click_update_button()
        {
            updateButton.Click();
        }

        public void click_delete_icon(string skill)
        {
            IWebElement deleteIconElement = driver.FindElement(By.XPath("//*[@data-tab='second']//td[text()='" + skill + "']/following-sibling::*[@class='right aligned']//*[@class='remove icon']"));
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

        public void update_skills(string existingSkill, string newSkill, String Level)
        {

            select_skills_tab();
            click_edit_icon(existingSkill);
            enter_skills(newSkill);
            select_skills_level(Level);
            click_update_button();
        }

        public void delete_skill(string skill)
        {
            select_skills_tab();
            click_delete_icon(skill);
        }

        public void delete_all_skills()
        {
            select_skills_tab();
            var deleteIconsElementList = driver.FindElements(By.XPath("//*[@data-tab='second']//*[@class='right aligned']//*[@class='remove icon']"));
            for (int i = 0; i < deleteIconsElementList.Count; i++)
            {
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
        public void verify_skills_added_success_message(string message)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.TextToBePresentInElement(successMessage, message));
            Assert.AreEqual(successMessage.Text, message);
            closeSuccessMessage();
        }

        public void verify_skills_updated_success_message(string message)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.TextToBePresentInElement(successMessage, message));
            Assert.AreEqual(successMessage.Text, message);
            closeSuccessMessage();

        }
        public void verify_skills_deleted_success_message(string message)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.TextToBePresentInElement(successMessage, message));
            Assert.AreEqual(successMessage.Text, message);
            closeSuccessMessage();

        }
        public void verify_skill_error_message(string message)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.TextToBePresentInElement(errorMessage, message));
            Assert.AreEqual(errorMessage.Text, message);
            closeSuccessMessage();
        }

    }

}
