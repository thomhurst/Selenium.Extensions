using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using TomLonghurst.Selenium.Extensions.Models;

namespace TomLonghurst.Selenium.Extensions.Extensions
{
    public static class WebDriverExtensions
    {
        public static Scroll Scroll(this IWebDriver webDriver)
        {
            return new Scroll(webDriver);
        }
        
        public static Wait Wait(this IWebDriver webDriver)
        {
            return new Wait(webDriver);
        }
        
        public static Popups Popups(this IWebDriver webDriver)
        {
            return new Popups(webDriver);
        }
        
        public static Mouse Mouse(this IWebDriver webDriver)
        {
            return new Mouse(webDriver);
        }
        
        public static BrowserInformation BrowserInformation(this IWebDriver webDriver)
        {
            return new BrowserInformation(webDriver);
        }

        public static IWebDriver GetRootWebDriver(this IWebDriver webDriver)
        {
            while (true)
            {
                if (!(webDriver is IWrapsDriver wrapsDriver))
                {
                    return webDriver;
                }
                
                webDriver = wrapsDriver.WrappedDriver;
            }
        }
    }
}