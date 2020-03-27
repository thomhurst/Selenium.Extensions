using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TomLonghurst.Selenium.Extensions.Models
{
    public class Wait
    {
        private readonly IWebDriver _webDriver;

        internal Wait(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void ForJavascriptToLoad(TimeSpan timeout)
        {
            WaitForJavascript(timeout, "return document.readyState == \"complete\"");
        }
        
        private void ForJavascriptToLoad(TimeSpan timeout, out TimeSpan remainingTimeout)
        {
            var stopwatch = Stopwatch.StartNew();

            ForJavascriptToLoad(timeout);
            
            var elapsed = stopwatch.Elapsed;

            remainingTimeout = timeout - elapsed;
        }
        
        public void ForJQuery(TimeSpan timeout)
        {
            ForJavascriptToLoad(timeout, out var remainingTimeout);
            WaitForJavascript(remainingTimeout, "return window.jQuery == null || jQuery.active == 0");
        }

        public void ForElementToBeVisible(By by, TimeSpan timeout)
        {
            new WebDriverWait(_webDriver, timeout).Until(ExpectedConditions.ElementIsVisible(by));
        }
        
        public void ForElementToBeClickable(By by, TimeSpan timeout)
        {
            new WebDriverWait(_webDriver, timeout).Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public void ForTitleToBe(string title, TimeSpan timeout)
        {
            new WebDriverWait(_webDriver, timeout).Until(ExpectedConditions.TitleIs(title));
        }
        
        public void ForTitleToContain(string title, TimeSpan timeout)
        {
            new WebDriverWait(_webDriver, timeout).Until(ExpectedConditions.TitleContains(title));
        }
        
        public void ForUrlToBe(string url, TimeSpan timeout)
        {
            new WebDriverWait(_webDriver, timeout).Until(ExpectedConditions.UrlToBe(url));
        }
        
        public void ForUrlToContain(string url, TimeSpan timeout)
        {
            new WebDriverWait(_webDriver, timeout).Until(ExpectedConditions.UrlContains(url));
        }

        public void ForUrlToMatch(string regex, TimeSpan timeout)
        {
            new WebDriverWait(_webDriver, timeout).Until(ExpectedConditions.UrlMatches(regex));
        }

        private void WaitForJavascript(TimeSpan timeout, string javascriptStatement)
        {
            new WebDriverWait(_webDriver, timeout)
                .Until(driver =>
                    ExecuteJavascriptPageFinishedLoadingCheck(driver, javascriptStatement));
        }

        private static bool ExecuteJavascriptPageFinishedLoadingCheck(IWebDriver driver, string javascript)
        {
            if (!(driver is IJavaScriptExecutor javaScriptExecutor))
            {
                return true;
            }

            var executeScriptResult = javaScriptExecutor.ExecuteScript(javascript);

            if (executeScriptResult is bool hasPageFinishedLoading)
            {
                return hasPageFinishedLoading;
            }

            if (bool.TryParse(executeScriptResult.ToString(), out hasPageFinishedLoading))
            {
                return hasPageFinishedLoading;
            }

            return true;
        }
    }
}