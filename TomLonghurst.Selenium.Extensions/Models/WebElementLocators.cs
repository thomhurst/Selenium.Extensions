using System;
using OpenQA.Selenium;

namespace TomLonghurst.Selenium.Extensions.Models
{
    public class WebElementLocators
    {
        private readonly IWebElement _webElement;

        internal WebElementLocators(IWebElement webElement)
        {
            _webElement = webElement;
        }

        private static IWebElement GetParent(ISearchContext searchContext)
        {
            return searchContext.FindElement(By.XPath(".."));
        }
        
        private static IWebElement GetChild(ISearchContext searchContext)
        {
            return searchContext.FindElement(By.XPath("./*"));
        }

        public IWebElement Parent => GetParent(_webElement);

        public IWebElement GrandParent(int count)
        {
            if (count <= 0)
            {
                return _webElement;
            }
            
            var webElement = _webElement;
            for (var i = 0; i <= count; i++)
            {
                webElement = GetParent(webElement);
            }

            return webElement;
        }

        public IWebElement AncestorWhere(Func<IWebElement, bool> condition)
        {
            var webElement = GetParent(_webElement);
            while (true)
            {
                if (condition(webElement))
                {
                    return webElement;
                }

                webElement = GetParent(webElement);
            }
        }
        
        public IWebElement Child => GetChild(_webElement);
        
        public IWebElement GrandChild(int count)
        {
            if (count <= 0)
            {
                return _webElement;
            }
            
            var webElement = _webElement;
            for (var i = 0; i <= count; i++)
            {
                webElement = GetChild(webElement);
            }

            return webElement;
        }
        
        public IWebElement DescendantWhere(Func<IWebElement, bool> condition)
        {
            var webElement = GetChild(_webElement);
            while (true)
            {
                if (condition(webElement))
                {
                    return webElement;
                }

                webElement = GetChild(webElement);
            }
        }
    }
}