using System;
using OpenQA.Selenium;
using TomLonghurst.Selenium.Extensions.Models;

namespace TomLonghurst.Selenium.Extensions.Extensions
{
    public static class SwitchToExtensions
    {
        public static SwitchToWindow Window(this ITargetLocator targetLocator)
        {
            return new SwitchToWindow(targetLocator);
        }
    }
}