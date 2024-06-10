using BoDi;
using OpenQA.Selenium;
using QA_Mars_OnboardingTask.Drivers;
using QA_Mars_OnboardingTask.Pages;
using TechTalk.SpecFlow;

namespace QA_Mars_OnboardingTask.Hooks
{
    [Binding]
    public sealed class Hooks : Driver
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly IObjectContainer _container;
        private SignInPage SignInPage_Obj;
        private LanguagesPage LanguagesPage_Obj;
        private SkillsPage SkillsPage_Obj;
        private IWebDriver driver;

        public Hooks(IObjectContainer container)
        {

            _container = container;
        }

        [BeforeScenario(Order = 0)]
        public void BeforeScenario()
        {
            this.driver = Initialize();
            _container.RegisterInstanceAs<IWebDriver>(this.driver);
            SignInPage_Obj = new SignInPage(this.driver);
            LanguagesPage_Obj = new LanguagesPage(this.driver);
            SkillsPage_Obj = new SkillsPage(this.driver);
            SignInPage_Obj.login("testuser@gmail.com", "12345678");
        }

        [BeforeScenario("addLanguageAsPreSetup")]
        public void PreSetupBeforeEachScenarioForLanguage()
        {
            LanguagesPage_Obj.add_new_language("English", "Basic");
            LanguagesPage_Obj.closeSuccessMessage();
        }

        [BeforeScenario("addSkillAsPreSetup")]
        public void PreSetupBeforeEachScenarioForSkill()
        {
            SkillsPage_Obj.add_new_skills("Java", "Beginner");
            SkillsPage_Obj.closeSuccessMessage();
        }

        [AfterScenario("cleanupLanguageAfterTest")]
        public void CleanupAfterScenarioForLanguage()
        {
            LanguagesPage_Obj.delete_all_languages();
        }

        [AfterScenario("cleanupSkillAfterTest")]
        public void CleanupAfterScenarioForSkill()
        {
            SkillsPage_Obj.delete_all_skills();
        }

        [AfterScenario()]
        public void CloseBrowserAfterScenario()
        {
            var driverObj = _container.Resolve<IWebDriver>();
            if (driverObj != null)
            {
                driverObj.Quit();
            }
        }
    }
}