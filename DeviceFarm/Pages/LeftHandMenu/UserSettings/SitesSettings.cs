using OpenQA.Selenium.Appium;

namespace DeviceFarm.Pages.LeftHandMenu.UserSettings
{
    public class SitesSettings : BasePage
    {
        public const string PageId = "SitesSettings";

        public SitesSettings TapLogOutButton()
        {
            Tap("LogOut");
            return this;
        }
        
        public SitesSettings TapName()
        {
            Tap("Name");
            return this;
        }

        
        public static string UserName, OriginalUserName;

        public SitesSettings GetUserName()
        {
            Driver.FindElement(MobileBy.AccessibilityId("Detail"));
            UserName = Driver.GetTextByAccessibilityId(MobileBy.AccessibilityId("Detail"));
            if (OriginalUserName == null) { OriginalUserName = UserName; }
            return this;
        }
        
        public SitesSettings TapEmail()
        {
            Tap("ChangeEmail");
            return this;
        }
        
        public SitesSettings TapPassword()
        {
            Tap("ChangePassword");
            return this;
        }
        
        public SitesSettings TapUserRole()
        {
            Tap("ChangeUserType");
            return this;
        }
        
        public SitesSettings TapAbout()
        {
            Tap("About");
            return this;
        }
        
        public SitesSettings TapLanguage()
        {
            Tap("ChangeLocalization");
            return this;
        }
        
        public SitesSettings TapServer()
        {
            Tap("SwitchServer");
            return this;
        }
        
        public SitesSettings TapNewsArchive()
        {
            Tap("NewsArchive");
            return this;
        }
        
        public SitesSettings TapResetDevices()
        {
            Tap("ResetDevices");
            return this;
        }
    }
}