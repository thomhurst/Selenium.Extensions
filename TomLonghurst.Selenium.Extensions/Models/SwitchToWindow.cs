using System;
using OpenQA.Selenium;

namespace TomLonghurst.Selenium.Extensions.Models
{
    public class SwitchToWindow
    {
        private readonly ITargetLocator _targetLocator;

        internal SwitchToWindow(ITargetLocator targetLocator)
        {
            _targetLocator = targetLocator;
        }
        
        public void WithTitle(string title)
        {
            var webDriver = _targetLocator.DefaultContent();
            
            foreach (var windowHandle in webDriver.WindowHandles)
            {
                webDriver.SwitchTo().Window(windowHandle);
                if (webDriver.Title == title)
                {
                    return;
                }
            }
            
            throw new ArgumentException($"Cannot find window named: {title}");
        }
        
        public void WithTitleContaining(string title)
        {
            var webDriver = _targetLocator.DefaultContent();
            
            foreach (var windowHandle in webDriver.WindowHandles)
            {
                webDriver.SwitchTo().Window(windowHandle);
                if (webDriver.Title.Contains(title))
                {
                    return;
                }
            }
            
            throw new ArgumentException($"Cannot find window with title containing: {title}");
        }
    }
}