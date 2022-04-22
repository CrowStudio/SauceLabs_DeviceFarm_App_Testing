using OpenQA.Selenium.Appium;

namespace DeviceFarm.Pages.LeftHandMenu
{
    public class LeftHandMenu : BasePage
    {
        public const string PageId = "LeftHandMenu";

        public LeftHandMenu TapNewSystemButton()
        {
            Tap("AddSite");
            return this;
        }

        public LeftHandMenu TapSystemByName(string siteName)
        {
            var elements = Driver.FindElements(MobileBy.AccessibilityId("Site"));
            foreach (var element in elements)
            {
                try
                {
                    var site = element.FindElement(Driver.FindXPathByText(siteName));
                    Tap(site);
                    Driver.ElementNotPresent(MobileBy.AccessibilityId("LeftHandMenu"));
                    break;
                }
                catch
                {
                     // ignored 
                }
            }
                
            return this;
        }
        
        public LeftHandMenu TapSystemSettingsByName(string siteName)
        {
            Driver.FindElement(PageId);
            var elements = Driver.FindElements(MobileBy.AccessibilityId("Site"));
            foreach (var element in elements)
            {
                try
                {
                    element.FindElement(Driver.FindXPathByText(siteName));
                    var siteElement = element.FindElement(MobileBy.AccessibilityId("SystemSettings"));
                    Tap(siteElement);
                    break;
                }
                catch
                {
                    // ignored 
                }
            }

            return this;
        }

        
        public static string SystemNameChanged;
        
        public LeftHandMenu ConfirmSystemName(string systemName)
        {
            var elements = Driver.FindElements(MobileBy.AccessibilityId("Site"));
            foreach (var element in elements)
            {
                try
                {
                     var name = element.FindElement(Driver.FindXPathByText(systemName));
                     SystemNameChanged = name.Text;
                    break;
                }
                catch
                {
                    // ignore
                }
            }

            return this;
        }

        public LeftHandMenu TapChangeNameButton()
        {
            Driver.Tap("ChangeName");
            return this;
        }

        public LeftHandMenu TapDeleteSystemButton()
        {
            Driver.Tap("DeleteSite");
            return this;
        }

        public LeftHandMenu TapSettingsButton()
        {
            Driver.Tap("Settings");
            return this;
        }
    }
}