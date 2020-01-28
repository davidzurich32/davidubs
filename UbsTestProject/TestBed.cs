using OpenQA.Selenium;
using UBSTestProject;

namespace UbsTestProject
{
    public class TestBed
    {
        public int firstValue { get; set; }
        public int secondValue { get; set; }
        public int result { get; set; }

        public IWebDriver webDriver { get; set; }

        public Configuration configuration { get; set; }


    }
}
