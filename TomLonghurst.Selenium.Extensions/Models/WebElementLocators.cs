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
    }
}