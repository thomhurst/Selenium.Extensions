using OpenQA.Selenium;
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
    }
}