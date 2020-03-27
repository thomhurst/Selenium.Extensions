using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TomLonghurst.Selenium.Extensions.Models
{
    public class Mouse
    {
        private readonly IWebDriver _driver;
        private Actions Actions => new Actions(_driver);

        internal Mouse(IWebDriver driver)
        {
            _driver = driver;
        }
        
        public Actions ClickAndHold(IWebElement onElement)
        {
            return Actions.ClickAndHold(onElement);
        }

        public Actions ClickAndHold()
        {
            return Actions.ClickAndHold();
        }

        public Actions Click(IWebElement onElement)
        {
            return Actions.Click(onElement);
        }

        public Actions Click()
        {
            return Actions.Click();
        }

        public Actions MoveToElement(IWebElement toElement)
        {
            return Actions.MoveToElement(toElement);
        }

        public Actions MoveToElement(IWebElement toElement, int offsetX, int offsetY)
        {
            return Actions.MoveToElement(toElement, offsetX, offsetY);
        }

        public Actions MoveToElement(IWebElement toElement, int offsetX, int offsetY, MoveToElementOffsetOrigin offsetOrigin)
        {
            return Actions.MoveToElement(toElement, offsetX, offsetY, offsetOrigin);
        }

        public Actions MoveByOffset(int offsetX, int offsetY)
        {
            return Actions.MoveByOffset(offsetX, offsetY);
        }

        public Actions RightClick(IWebElement onElement)
        {
            return Actions.ContextClick(onElement);
        }

        public Actions RightClick()
        {
            return Actions.ContextClick();
        }

        public Actions Release(IWebElement onElement)
        {
            return Actions.Release(onElement);
        }

        public Actions Release()
        {
            return Actions.Release();
        }

        public Actions DragAndDropToOffset(IWebElement source, int offsetX, int offsetY)
        {
            return Actions.DragAndDropToOffset(source, offsetX, offsetY);
        }

        public void DoubleClick(By by)
        {
            Actions.DoubleClick(GetElement(by)).Perform();
        }
        
        public void DoubleClick()
        {
            Actions.DoubleClick().Perform();
        }
        
        public void DragAndDrop(By from, By to)
        {
            Actions.DragAndDrop(GetElement(from), GetElement(to)).Perform();
        }

        private IWebElement GetElement(By by)
        {
            return _driver.FindElement(by);
        }
    }
}