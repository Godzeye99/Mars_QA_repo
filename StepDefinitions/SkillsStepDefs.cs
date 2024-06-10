using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using QA_Mars_OnboardingTask.Pages;

namespace QA_Mars_OnboardingTask.StepDefinitions
{
    [Binding]
    public class SkillsStepDefs
    {
        private SkillsPage Skill_Obj;

        public SkillsStepDefs(IWebDriver driver)
        {
            Skill_Obj = new SkillsPage(driver);
        }

        [Given(@"I navigate to skills")]
        public void navigate_to_skills()
        {
            Skill_Obj.select_skills_tab();

        }

        [When(@"I click skill Add New button")]
        public void click_skill_add_new_button()
        {
            Skill_Obj.click_add_new_skills_button();
        }

        [When(@"I click skill Add button")]
        public void click_skill_add_button()
        {
            Skill_Obj.click_add_button();
        }

        [When(@"I add a new skill '([^']*)' with level '([^']*)'")]
        public void add_skill(string Skill, string Level)
        {
            Skill_Obj.add_new_skills(Skill, Level);

        }

        [When(@"I edit '([^']*)' skill to '([^']*)' with level '([^']*)'")]
        public void update_skill(string existingSkill, string newSkill, string Level)
        {
            Skill_Obj.update_skills(existingSkill, newSkill, Level);

        }

        [When(@"I delete an existing skill '([^']*)'")]
        public void delete_skill(string skill)
        {
            Skill_Obj.delete_skill(skill);

        }

        [Then(@"I expect skill add success message as '([^']*)'")]
        public void verify_add_success_message(string message)
        {
            Skill_Obj.verify_skills_added_success_message(message);

        }

        [Then(@"I expect skill update success message as '([^']*)'")]
        public void verify_update_success_message(string message)
        {
            Skill_Obj.verify_skills_updated_success_message(message);

        }

        [Then(@"I expect skill delete success message as '([^']*)'")]
        public void verify_delete_success_message(string message)
        {
            Skill_Obj.verify_skills_deleted_success_message(message);

        }

        [Then(@"I expect skill error message as '([^']*)'")]
        public void verify_error_message(string message)
        {
            Skill_Obj.verify_skill_error_message(message);
        }
    }
}
