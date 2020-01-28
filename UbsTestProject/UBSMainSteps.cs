using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using UBSTestProject;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace UbsTestProject
{
    [Binding]
    public class UBSMainSteps
    {
        TestBed testBed;
        IOHelper iOHelper;
        SeleniumHelper seleniumHelper;

        UBSMainSteps(TestBed testBed, IOHelper iOHelper, SeleniumHelper seleniumHelper)
        {
            this.testBed = testBed;
            this.iOHelper = iOHelper;
            this.seleniumHelper = seleniumHelper;
        }


        [Given(@"the user opens the main UBS webpage")]
        public void GivenTheUserOpensTheMainUBSWebpage()
        {
            IWebDriver webDriver = getWebDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            webDriver.Url = "https://www.ubs.com";
            webDriver.Manage().Window.Maximize();
            testBed.WebDriver = webDriver;
        }

        private IWebDriver getWebDriver()
        {
            var configuration = testBed.Configuration;
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
            seleniumHelper.click(testBed.WebDriver, testBed.SeleniumIds.languageButton);
            

        }

        

        [Then(@"the main UBS webpage is opened in the preferred language")]
        public void ThenTheMainUBSWebpageIsOpenedInThePreferredLanguage()
        {
            testBed.WebDriver.Quit();
        }


    }
}
