using OpenQA.Selenium.Appium;

namespace DeviceFarm.Pages
{
    public class Welcome : BasePage
    {
        public const string PageId = "Welcome";

        public Welcome TapLoginButton()
        {
            Tap("LogIn");
            return this;
        }

        public Welcome TapLocalizationButton()
        {
            Tap("Localization");
            return this;
        }

        public static string PageLanguage;
        
        public Welcome ConfirmLocaleSettings()
        { 
            PageLanguage = Driver.GetTextByAccessibilityId(MobileBy.AccessibilityId("Locale"));
            return this;
        }
    }
}