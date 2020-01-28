using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using UBSTestProject;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace UbsTestProject
{
    [Binding]
    public class UBSMainSteps
    {
        TestBed testBed;
        IOHelper iOHelper;
        UBSMainSteps(TestBed testBed, IOHelper iOHelper)
        {
            this.testBed = testBed;
            this.iOHelper = iOHelper;
        }

        
        [Given(@"the user opens the main UBS webpage")]
        public void GivenTheUserOpensTheMainUBSWebpage()
        {
            IWebDriver webDriver = getWebDriver();
            webDriver.Url = "https://www.ubs.com";
            webDriver.Manage().Window.Maximize();
            testBed.webDriver = webDriver;
        }

        private IWebDriver getWebDriver()
        {
            var configuration = testBed.configuration;
            var directory = iOHelper.getDriversDirectory();
            IWebDriver webDriver;
            switch (configuration.browser.ToUpper())
            {
                case "FIREFOX":
                    webDriver = new FirefoxDriver(directory);
                    break;
                case "CHROME":
                    webDriver = new ChromeDriver(directory);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return webDriver;
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
