using OpenQA.Selenium;

namespace UbsTestProject
{
    public class TestBed
    {
        public IWebDriver WebDriver { get; set; }

        public Configuration Configuration { get; set; }
        public SeleniumIds SeleniumIds { get; set; }

        public SeleniumLanguageSpecificIds SeleniumLanguageSpecificIds { get; set; }
    }
}
