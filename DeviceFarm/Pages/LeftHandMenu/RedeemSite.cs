using OpenQA.Selenium.Appium;

namespace DeviceFarm.Pages.LeftHandMenu
{
    public class RedeemSite : BasePage
    {
        public const string PageId = "RedeemSite";

        public RedeemSite EnterSystemCode(string systemCode)
        {
            Driver.FindElement(MobileBy.AccessibilityId("CodeEntry"));
            SendKey("CodeEntry",systemCode);
            return this;
        }

        public RedeemSite TapRedeemButton()
        {
            Tap("Done");
            return this;
        }
    }
}