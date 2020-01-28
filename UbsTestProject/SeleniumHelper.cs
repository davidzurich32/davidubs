using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UBSTestProject
{
    public class SeleniumHelper
    {
        public static Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        {
            return driver =>
            {
                var element = driver.FindElement(locator);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            };
        }

        public void click(IWebDriver webDriver, string buttonName)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ElementIsClickable(By.Id(buttonName)));
            clickableElement.Click();
        }
    }
}
