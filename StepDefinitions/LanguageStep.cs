using Hemz_QA_Mars.Pages;
using TechTalk.SpecFlow;

namespace Hemz_QA_Mars.StepDefinitions
{
    [Binding]
    public class LanguageStep
    {
        Languages Language_Obj = new Languages();

        [Given(@"I navigate to Language")]
        public void navigate_to_Language()
        {
            Language_Obj.select_language_tab();

        }

        [When(@"I add a new langauge '([^']*)' with level '([^']*)'")]
        public void add_skill(string Skill, string Level)
        {
            Language_Obj.add_new_language(Skill, Level);

        }

        [When(@"I edit skill to '([^']*)' with level '([^']*)'")]
        public void update_skill(string Skill, string Level)
        {
            Language_Obj.update_language(Skill, Level);

        }

        [When(@"When I delete an existing skill '([^']*)'")]
        public void delete_skill()
        {
            Language_Obj.delete_language();

        }

        [Then(@"Then I expect add success message")]
        public void verify_add_success_message()
        {
            Language_Obj.verify_language_added_success_message();

        }

        [Then(@"Then I expect update success message")]
        public void verify_update_success_message()
        {
            Language_Obj.verify_language_updated_success_message();

        }

        [Then(@"Then I expect delete success message")]
        public void verify_delete_success_message()
        {
            Language_Obj.verify_language_deleted_success_message();

        }


    }
}
