using OpenQA.Selenium.Appium;

namespace DeviceFarm.Pages.RightMenu
{
    public class RightMenu : BasePage
    {
        public const string PageId = "SiteName";
        
        public static string SystemName;
        
        public RightMenu GetMenuSystemName(string siteName)
        {
            var element = Driver.FindElement(MobileBy.AccessibilityId("SiteName"));
            SystemName = element.Text;
            return this;
        }
        
        public RightMenu TapAddDevice()
        {            
            Tap("AddDevice");
            return this;
        }
        
        public RightMenu TapScenes()
        {
            Tap("Scenes");
            return this;
        }
        public RightMenu TapScheduling()
        {
            Tap("Scheduling");
            return this;
        }
        
        public RightMenu TapConfigureInputs()
        {
            Tap("ConfigureInputs");
            return this;
        }
        
        public RightMenu TapLoadSettings()
        {
            Tap("LoadSettings");
            return this;
        }
        
        public RightMenu TapUsers()
        {
            Tap("ManageUsers");
            return this;
        }
        
        public RightMenu TapTransferToEndUser()
        {
            Tap("TransferToEndUser");
            return this;
        }
        
        public RightMenu TapAddColleague()
        {
            Tap("AddColleague");
            return this;
        }
        
        public RightMenu TapDevices()
        {
            Tap("Devices");
            return this;
        }
        
        public RightMenu TapRooms()
        {
            Tap("Rooms");
            return this;
        }
        
        public RightMenu TapSupport()
        {
            Tap("Support");
            return this;
        }
        
    }
}