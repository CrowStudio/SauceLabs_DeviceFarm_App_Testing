using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace DeviceFarm.Pages
{
    public class BasePage
    {
        public static bool PageLoaded;

        protected static DriverWrapper Driver => AppInitializer.Wrapper();

        public BasePage ConfirmLoad(string id)
        {
            PageLoaded = Driver.FindElement(MobileBy.AccessibilityId(id)).Displayed;
            return this;
        }

        public BasePage TapBack()
        {
            Driver.TapBack();
            return this;
        }

        protected BasePage Tap(string id)
        {
            Driver.Tap(id);
            return this;
        }

        protected BasePage Tap(By by)
        {
            Driver.Tap(by);
            return this;
        }

        protected BasePage Tap(IWebElement element)
        {
            Driver.Tap(element);
            return this;
        }

        protected BasePage TapAndHold(IWebElement element)
        {
            Driver.TapAndHold(element);
            return this;
        }

        protected BasePage SendKey(string id, string text)
        {
            Driver.SendKey(id, text);
            return this;
        }

        protected BasePage SendKey(By by, string text)
        {
            Driver.SendKey(by, text);
            return this;
        }
    }
}