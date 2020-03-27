using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TomLonghurst.Selenium.Extensions.Models
{
    public class Scroll
    {
        private readonly IWebDriver _driver;
        private Actions Actions => new Actions(_driver);

        internal Scroll(IWebDriver driver)
        {
            _driver = driver;
        }
        
        public void To(By by)
        {
            To(_driver.FindElement(by));
        }

        public void To(IWebElement webElement)
        {
            Actions.MoveToElement(webElement).Perform();
        }

        public void Down(uint pixels = 500)
        {
            ((IJavaScriptExecutor) _driver).ExecuteScript($"window.scrollBy(0,{pixels});");
        }
        
        public void Up(uint pixels = 500)
        {
            ((IJavaScriptExecutor) _driver).ExecuteScript($"window.scrollBy(0,-{pixels});");
        }
        
        public void Left(uint pixels = 500)
        {
            ((IJavaScriptExecutor) _driver).ExecuteScript($"window.scrollBy(-{pixels},0);");
        }
        
        public void Right(uint pixels = 500)
        {
            ((IJavaScriptExecutor) _driver).ExecuteScript($"window.scrollBy({pixels},0);");
        }
    }
}