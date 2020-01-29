using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            switch (configuration.Browser.ToUpper())
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
        [Given(@"the user selects his preferred language")]
        public void WhenTheUserSelectsHisPreferredLanguage()
        {
            String text = seleniumHelper.getTextById(testBed.WebDriver, testBed.SeleniumIds.LanguageButton);
            
            switch (testBed.Configuration.Language.ToUpper())
            {
                case "ENGLISH":
                    if (!text.Equals(testBed.SeleniumIds.EnglishAbbreviation))
                    {
                        seleniumHelper.clickById(testBed.WebDriver, testBed.SeleniumIds.LanguageButton);
                        seleniumHelper.clickById(testBed.WebDriver, testBed.SeleniumIds.EnglishLanguage);
                    }
                    
                    break;
                case "GERMAN":
                    if (!text.Equals(testBed.SeleniumIds.GermanAbbreviation))
                    {
                        seleniumHelper.clickById(testBed.WebDriver, testBed.SeleniumIds.LanguageButton);
                        seleniumHelper.clickById(testBed.WebDriver, testBed.SeleniumIds.GermanLanguage);
                    }
                    
                    break;
                default:
                    throw new NotImplementedException();

            }
        }

        

        [Then(@"the main UBS webpage is opened in the preferred language")]
        public void ThenTheMainUBSWebpageIsOpenedInThePreferredLanguage()
        {
            String text = seleniumHelper.getTextByClass(testBed.WebDriver, testBed.SeleniumIds.HeaderTitle);
            Assert.AreEqual(testBed.Configuration.Title, text);
            
        }


    }
}
