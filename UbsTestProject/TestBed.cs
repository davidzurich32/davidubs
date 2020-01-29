using OpenQA.Selenium;

namespace UbsTestProject
{
    /// <summary>
    /// class used to communicate specflow steps between them
    /// </summary>
    public class TestBed
    {
        public IWebDriver WebDriver { get; set; }

        public Configuration Configuration { get; set; }
        public SeleniumIds SeleniumIds { get; set; }

        public SeleniumLanguageSpecificIds SeleniumLanguageSpecificIds { get; set; }
    }
}
