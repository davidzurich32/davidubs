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
        /// <param name="seleniumHelper">an instance of the seleniumhelper, selenium utility class<seealso cref="SeleniumHelper"></param>
        /// <param name="testBed">an instance of the testbed, containing data needed between steps<seealso cref="TestBed"></param>
        MortgageSteps(SeleniumHelper seleniumHelper, TestBed testBed)
        {
            this.seleniumHelper = seleniumHelper;
            this.testBed = testBed;
        }

        [When(@"the user navigates to the mortgage calculator screen")]
        public void WhenTheUserNavigatesToTheMortgageScreen()
        {
            seleniumHelper.clickByPath(testBed.WebDriver, testBed.SeleniumLanguageSpecificIds.PrivateClients);
            seleniumHelper.clickById(testBed.WebDriver, testBed.SeleniumIds.Mortgage);
            seleniumHelper.clickById(testBed.WebDriver, testBed.SeleniumIds.MortgageCalculator);
           
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
