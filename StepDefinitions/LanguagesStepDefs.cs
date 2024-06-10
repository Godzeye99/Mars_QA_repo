using System;
using OpenQA.Selenium;
using QA_Mars_OnboardingTask.Pages;
using TechTalk.SpecFlow;

namespace QA_Mars_OnboardingTask.StepDefinitions
{
    [Binding]
    public class LanguagesStepDefs
    {
        private LanguagesPage Language_Obj;

        public LanguagesStepDefs(IWebDriver driver)
        {
            Language_Obj = new LanguagesPage(driver);
        }

        [Given(@"I navigate to Language")]
        public void navigate_to_Language()
        {
            Language_Obj.select_language_tab();

        }

        [When(@"I click language Add New button")]
        public void click_language_add_new_button()
        {
            Language_Obj.click_add_new_language_button();
        }

        [When(@"I click language Add button")]
        public void click_language_add_button()
        {
            Language_Obj.click_add_button();
        }

        [When(@"I add a new langauge '([^']*)' with level '([^']*)'")]
        public void add_skill(string language, string level)
        {
            Language_Obj.add_new_language(language, level);

        }

        [When(@"I edit '([^']*)' language to '([^']*)' with level '([^']*)'")]
        public void update_language(string existingLanguage, string newLanguage, string level)
        {
            Language_Obj.update_language(existingLanguage, newLanguage, level);
        }

        [When(@"I delete an existing language '([^']*)'")]
        public void delete_language(string language)
        {
            Language_Obj.delete_language(language);
        }

        [Then(@"I expect language add success message as '([^']*)'")]
        public void verify_add_success_message(string message)
        {
            Language_Obj.verify_language_added_success_message(message);

        }

        [Then(@"I expect language update success message as '([^']*)'")]
        public void verify_update_success_message(string message)
        {
            Language_Obj.verify_language_updated_success_message(message);

        }

        [Then(@"I expect language delete success message as '([^']*)'")]
        public void verify_delete_success_message(string message)
        {
            Language_Obj.verify_language_deleted_success_message(message);

        }

        [Then(@"I expect language error message as '([^']*)'")]
        public void verify_language_error_message(string message)
        {
            Language_Obj.verify_language_error_message(message);

        }

    }
}
