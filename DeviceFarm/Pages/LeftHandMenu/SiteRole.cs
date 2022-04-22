using OpenQA.Selenium.Appium;

namespace DeviceFarm.Pages.LeftHandMenu
{
    public class SiteRole : BasePage
    {
        public const string PageId = "SiteRole";

        public SiteRole SelectUserRole(string role)
        {
            Driver.FindElement("SiteRole");
            var elements = Driver.FindElements(MobileBy.AccessibilityId("Role"));
                foreach (var element in elements)
                {
                    try
                    {
                        element.FindElement(Driver.FindXPathByText(role));
                        Tap(element);
                        break;
                    }
                    catch
                    {
                        // ignored
                    }
                }

            return this;
        }
    }
}