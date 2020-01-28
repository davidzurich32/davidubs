using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace UbsTestProject
{
    [Binding]
    public class UBSMainSteps
    {
        TestBed testBed;
        UBSMainSteps(TestBed testBed)
        {
            this.testBed = testBed;          
        }

        
        [Given(@"the user opens the main UBS webpage")]
        public void GivenTheUserOpensTheMainUBSWebpage()
        {
            var directory = getSolutionDirectory();
            var webDriver = new ChromeDriver(directory);
            webDriver.Url = "https://www.ubs.com";
            testBed.webDriver = webDriver;
        }

        private static string getSolutionDirectory()
        {
            var currentDir = Environment.CurrentDirectory;
            var directory = new DirectoryInfo(
            Path.GetFullPath(Path.Combine(currentDir, @"..\UbsTestProject\")));
            return directory.ToString();
        }

        [When(@"the user selects his preferred language")]
        public void WhenTheUserSelectsHisPreferredLanguage()
        {
            
        }

        [Then(@"the main UBS webpage is opened in the preferred language")]
        public void ThenTheMainUBSWebpageIsOpenedInThePreferredLanguage()
        {
            testBed.webDriver.Quit();
        }


    }
}
