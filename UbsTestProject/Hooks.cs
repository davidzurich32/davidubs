using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using TechTalk.SpecFlow;
using UbsTestProject;

namespace UBSTestProject
{
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
            testBed.configuration = configuration;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
