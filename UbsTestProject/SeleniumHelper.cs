using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace UbsTestProject
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

        public void clickById(IWebDriver webDriver, string buttonName)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ElementIsClickable(By.Id(buttonName)));
            clickableElement.Click();
        }

        internal void clickByPath(IWebDriver webDriver, string path)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromMinutes(1));

            String filter = "./*[contains(@data-di-id," + "path" + ")]";
            var clickableElement = wait.Until(ElementIsClickable(By.XPath(filter)));
            clickableElement.Click();
        }

        internal void writeIntoElementById(IWebDriver webDriver, string id, string value)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ElementIsClickable(By.Id(id)));
            clickableElement.Clear();
            clickableElement.SendKeys(value);
        }

        public string getTextById(IWebDriver webDriver, string buttonName)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ElementIsClickable(By.Id(buttonName)));
            return clickableElement.Text;
        }

        public void clickByClass(IWebDriver webDriver, string buttonName)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ElementIsClickable(By.ClassName(buttonName)));
            clickableElement.Click();
        }

        public string getTextByClass(IWebDriver webDriver, string buttonName)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ElementIsClickable(By.ClassName(buttonName)));
            return clickableElement.Text;
        }
    }
}
