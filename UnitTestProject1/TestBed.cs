using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    public class TestBed
    {
        public int firstValue { get; set; }
        public int secondValue { get; set; }
        public int result { get; set; }

        public IWebDriver webDriver { get; set; }


    }
}
