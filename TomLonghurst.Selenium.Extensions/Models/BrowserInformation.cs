using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace TomLonghurst.Selenium.Extensions.Models
{
    public class BrowserInformation
    {
        private readonly IWebDriver _webDriver;

        internal BrowserInformation(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string UserAgent => _webDriver.ExecuteJavaScript<string>("return navigator.userAgent");
        public string Platform => _webDriver.ExecuteJavaScript<string>("return navigator.platform");
    }
}