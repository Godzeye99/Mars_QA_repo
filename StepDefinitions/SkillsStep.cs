using Hemz_QA_Mars.Pages;
using TechTalk.SpecFlow;

namespace Hemz_QA_Mars.StepDefinitions
{
    [Binding]
    public class SkillsStep
    {
        Skills Skill_Obj = new Skills();

        [Given(@"I navigate to skills")]
        public void navigate_to_skills()
        {
            Skill_Obj.select_skills_tab();

        }

        [When(@"I add a new langauge '([^']*)' with level '([^']*)'")]
        public void add_skill(string Skill, string Level)
        {
            Skill_Obj.add_new_skills(Skill, Level);

        }

        [When(@"I edit skill to '([^']*)' with level '([^']*)'")]
        public void update_skill(string Skill, string Level)
        {
            Skill_Obj.update_skills(Skill, Level);

        }

        [When(@"When I delete an existing skill '([^']*)'")]
        public void delete_skill()
        {
            Skill_Obj.delete_skills();

        }

        [Then(@"Then I expect add success message")]
        public void verify_add_success_message()
        {
            Skill_Obj.verify_skills_added_success_message();

        }

        [Then(@"Then I expect update success message")]
        public void verify_update_success_message()
        {
            Skill_Obj.verify_skills_updated_success_message();

        }

        [Then(@"Then I expect delete success message")]
        public void verify_delete_success_message()
        {
            Skill_Obj.verify_skills_deleted_success_message();

        }


    }
}
