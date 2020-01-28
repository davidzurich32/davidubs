using OpenQA.Selenium;
using UBSTestProject;

namespace UbsTestProject
{
    public class TestBed
    {
        public IWebDriver WebDriver { get; set; }

        public Configuration Configuration { get; set; }
        public SeleniumIds SeleniumIds { get; set; }
    }
}
