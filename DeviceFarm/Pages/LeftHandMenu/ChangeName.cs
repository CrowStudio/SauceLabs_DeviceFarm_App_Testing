using OpenQA.Selenium.Appium;

namespace DeviceFarm.Pages.LeftHandMenu
{
    public class ChangeName : BasePage
    {
        public const string PageId = "ChangeName";

        public ChangeName TapSharedSystemName()
        {
            Tap("SystemName");
            return this;
        }
        
        public ChangeName TapPersonalNickname()
        {
            Tap("Nickname");
            return this;
        }

        public ChangeName TapSaveButton()
        {
            Tap("Done");
            Driver.ElementNotPresent(MobileBy.AccessibilityId(PageId));
            return this;
        }
    }
}