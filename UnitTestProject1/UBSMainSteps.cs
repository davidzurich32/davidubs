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
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            testBed.firstValue = p0;
        }
        
        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int p0)
        {
            testBed.secondValue = p0;
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            testBed.result = testBed.firstValue + testBed.secondValue;
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.AreEqual(p0, testBed.result);
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

    }
}
