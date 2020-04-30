using OpenQA.Selenium;
using TomLonghurst.Selenium.Extensions.Models;

namespace TomLonghurst.Selenium.Extensions.Extensions
{
    public static class WebElementExtensions
    {
        public static WebElementLocators Locators(this IWebElement webElement)
        {
            return new WebElementLocators(webElement);
        } 
    }
}