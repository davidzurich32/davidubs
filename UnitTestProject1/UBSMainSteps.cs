using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.IO;

namespace UnitTestProject1
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
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
            Path.GetFullPath(Path.Combine(currentDir, @"..\")));
            IWebDriver webDriver = new ChromeDriver(directory.ToString());          
            webDriver.Url = "https://www.google.es";
            testBed.webDriver = webDriver;
        }

        [When(@"the user selects his preferred language")]
        public void WhenTheUserSelectsHisPreferredLanguage()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the main UBS webpage is opened in the preferred language")]
        public void ThenTheMainUBSWebpageIsOpenedInThePreferredLanguage()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
