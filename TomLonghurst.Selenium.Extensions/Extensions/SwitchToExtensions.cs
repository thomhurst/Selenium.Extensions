using System;
using OpenQA.Selenium;

namespace TomLonghurst.Selenium.Extensions.Extensions
{
    public static class SwitchToExtensions
    {
        public static void WindowWithTitle(this ITargetLocator targetLocator, string title)
        {
            var webDriver = targetLocator.DefaultContent();
            
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
        
        public static void WindowWithTitleContaining(this ITargetLocator targetLocator, string title)
        {
            var webDriver = targetLocator.DefaultContent();
            
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