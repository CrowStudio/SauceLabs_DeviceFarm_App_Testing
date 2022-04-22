using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace DeviceFarm.Pages.LeftHandMenu
{
    public class OwnerOverview : BasePage
    {
        public const string PageId = "OwnerOverview";

        private IWebElement _thisIsYou;

        public OwnerOverview ConfirmUser(string user)
        {
            var elements = Driver.FindElements(MobileBy.AccessibilityId("ConfirmUser"));
            foreach (var element in elements)
            {
                try
                {
                    element.FindElement(Driver.FindXPathByText("This is you"));
                    _thisIsYou = element;
                    break;
                }
                catch
                {
                    // ignored
                }

                _thisIsYou.FindElement(Driver.FindXPathByText(user));
            }
            
            return this;
        }
        
        public OwnerOverview DeselectLocalAccessForInstaller()
        {
            var removeLocalAccess = Driver.FindElementByText("Installer");
            Tap(removeLocalAccess);
            Driver.FindElementByText("No access");
            return this;
        }

        public OwnerOverview TapThisLookGood()
        {
            Tap("Done");
            return this;
        }

        public OwnerOverview TapYesToRevokeAccess()
        {
            var yesButton = Driver.FindElementByText("YES");
            Tap(yesButton);
            Driver.ElementNotPresent(By.ClassName("RevokeAccess"));
            return this;
        }
    }
}