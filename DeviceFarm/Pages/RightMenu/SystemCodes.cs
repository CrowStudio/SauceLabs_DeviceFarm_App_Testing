using DeviceFarm.Tests.RightMenuTests;
using OpenQA.Selenium.Appium;

namespace DeviceFarm.Pages.RightMenu
{
    public class SystemCodes : BasePage
    {
        public const string PageId = "SystemCodes";

        public SystemCodes CopyOwnerCode()
        {
            TapAndHold(Driver.FindElement("AdminCode"));
            ConfirmCopy("Owner");
            SystemCodesTest.OwnerCode = GetCodeFromElement("AdminCode");
            SystemCodesTest.CopiedCode = Driver.GetClipboardAndroid();
            return this;
        }

        public SystemCodes CopyUserCode()
        {
            TapAndHold(Driver.FindElement("UserCode"));
            ConfirmCopy("User");
            SystemCodesTest.UserCode = GetCodeFromElement("UserCode");
            SystemCodesTest.CopiedCode = Driver.GetClipboardAndroid();
            return this;
        }
        
        public SystemCodes CopyInstallerCode()
        {     
            TapAndHold(Driver.FindElement("InstallerCode"));
            ConfirmCopy("Installer");
            SystemCodesTest.InstallerCode = GetCodeFromElement("InstallerCode");
            SystemCodesTest.CopiedCode = Driver.GetClipboardAndroid();
            return this;
        }

        private static string GetCodeFromElement(string id)
        {
            var code = Driver.FindElement(id);
            return code.FindElement(MobileBy.AccessibilityId( "Detail")).Text;
        }
        
        private static void ConfirmCopy(string the)
        {
            var copyConfirm = Driver.FindXPathByText($"{the} code is copied to clipboard");
            Driver.ElementNotPresent(copyConfirm);
        }
    }
}