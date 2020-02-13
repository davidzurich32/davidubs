using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace UbsTestProject
{
    [Binding]
    public class MortgageSteps
    {
        private SeleniumHelper seleniumHelper;
        private TestBed testBed;

        /// <summary>
        /// Steps that implement the mortgages scenarios.
        /// </summary>
        /// <param name="seleniumHelper">Selenium utility class<seealso cref="SeleniumHelper"></param>
        /// <param name="testBed">Parameter containing the data needed between steps<seealso cref="TestBed"></param>
        MortgageSteps(SeleniumHelper seleniumHelper, TestBed testBed)
        {
            this.seleniumHelper = seleniumHelper;
            this.testBed = testBed;
        }

        [When(@"the user navigates to the mortgage calculator screen")]
        public void WhenTheUserNavigatesToTheMortgageScreen()
        {
            var webDriver = testBed.WebDriver;
            webDriver.Url = "https://www.ubs.com/ch/en/private/mortgages/mortgage-calculator.html";
            webDriver.Manage().Window.Maximize();
            testBed.WebDriver = webDriver;

        }
        
        [When(@"enters following values")]
        public void WhenEntersFollowingValues(Table table)
        {
            var dictionary = ToDictionary(table);
            seleniumHelper.writeIntoElementById(testBed.WebDriver, testBed.SeleniumIds.MortgagePrice, dictionary["Purchase"]);
            seleniumHelper.writeIntoElementById(testBed.WebDriver, testBed.SeleniumIds.Income, dictionary["Income"]);
            seleniumHelper.writeIntoElementById(testBed.WebDriver, testBed.SeleniumIds.Equity, dictionary["Equity"]);
        }

        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        [Then(@"the user can get the credit")]
        public void ThenTheUserCanGetTheCredit()
        {
            seleniumHelper.clickById(testBed.WebDriver, testBed.SeleniumIds.MortgageSubmitQuery);
            string result = seleniumHelper.getTextById(testBed.WebDriver, testBed.SeleniumIds.MortgageResultParagraph);
            Assert.AreEqual(testBed.Configuration.MortgagePositiveResult, result);

        }
        
        [Then(@"the user cannot get the credit")]
        public void ThenTheUserCannotGetTheCredit()
        {
            seleniumHelper.clickById(testBed.WebDriver, testBed.SeleniumIds.MortgageSubmitQuery);
            string result = seleniumHelper.getTextById(testBed.WebDriver, testBed.SeleniumIds.MortgageResultParagraph);
            Assert.AreEqual(testBed.Configuration.MortgageNegativeResult, result);
        }
    }
}
