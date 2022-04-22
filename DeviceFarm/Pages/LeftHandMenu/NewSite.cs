using OpenQA.Selenium.Appium;

namespace DeviceFarm.Pages.LeftHandMenu
{
    public class NewSite : BasePage
    {
        public const string PageId = "NewSite";

        public static bool ActiveAddButton;
        
        public NewSite ConfirmAddButton()
        {
            Driver.FindElement(MobileBy.AccessibilityId("Done")); 
            ActiveAddButton = Driver.IsButtonEnabled("Done");
            return this;
        }
        
        public NewSite EnterSystemName(string systemName)
        {
            Driver.FindElement(MobileBy.AccessibilityId("NameEntry"));
            SendKey("NameEntry",systemName);
            return this;
        }
        
        public NewSite TapAddButton()
        {
            Tap("Done");
            return this;
        }
    }
}