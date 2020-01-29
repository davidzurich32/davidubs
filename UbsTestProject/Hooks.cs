using System;
using TechTalk.SpecFlow;

namespace UbsTestProject
{
    /// <summary>
    /// Contains the actions to do before and after each step
    /// </summary>
    [Binding]
    public sealed class Hooks
    {
        private TestBed testBed;
        private IOHelper iOHelper;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        Hooks(TestBed testBed, IOHelper iOHelper)
        {
            this.testBed = testBed;
            this.iOHelper = iOHelper;
            
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            Configuration configuration = iOHelper.readJson<Configuration>("configuration.json");
            SeleniumIds seleniumIds = iOHelper.readJson<SeleniumIds>("Selenium.json");
            testBed.Configuration = configuration;
            testBed.SeleniumIds = seleniumIds;
            SeleniumLanguageSpecificIds seleniumLanguageSpecificIds;
            switch(configuration.Language.ToUpper())
            {
                case "ENGLISH":
                    seleniumLanguageSpecificIds = iOHelper.readJson<SeleniumLanguageSpecificIds>("SeleniumEnglish.json");
                    testBed.SeleniumLanguageSpecificIds = seleniumLanguageSpecificIds;
                    break;
                case "GERMAN":
                    seleniumLanguageSpecificIds = iOHelper.readJson<SeleniumLanguageSpecificIds>("SeleniumGerman.json");
                    testBed.SeleniumLanguageSpecificIds = seleniumLanguageSpecificIds;
                    break;
                default:
                    throw new NotImplementedException();
            }
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            testBed.WebDriver.Quit();
        }
    }
}
