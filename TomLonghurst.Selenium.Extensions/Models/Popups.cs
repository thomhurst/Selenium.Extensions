using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TomLonghurst.Selenium.Extensions.Models
{
    public class Popups
    {
        private readonly IWebDriver _driver;

        internal Popups(IWebDriver webDriver)
        {
            _driver = webDriver;
        }
        
        public void ClosePopUp()
        {
            ClosePopUp(TimeSpan.FromSeconds(30));
        }

        public void ClosePopUp(TimeSpan timeout)
        {
            var currentWindowCount = _driver.WindowHandles.Count;
            
            _driver.Close();
            
            new WebDriverWait(_driver, timeout).Until(d => d.WindowHandles.Count != currentWindowCount);
        }
        
        public void ClickAndWaitForPopUp(By by)
        {
            ClickAndWaitForPopUp(by, TimeSpan.FromSeconds(30));
        }

        public void ClickAndWaitForPopUp(By by, TimeSpan timeout)
        {
            var currentWindowCount = _driver.WindowHandles.Count;
            
            _driver.FindElement(by).Click();
            
            new WebDriverWait(_driver, timeout).Until(d => d.WindowHandles.Count != currentWindowCount);
        }
    }
}