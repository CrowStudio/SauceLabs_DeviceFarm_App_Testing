using OpenQA.Selenium.Appium;

namespace DeviceFarm.Pages.LeftHandMenu
{
    public class DeleteSite : BasePage
    {
        public const string PageId = "DeleteSite";
        public DeleteSite EnterPassword(string password)
        {
            Driver.FindElement(MobileBy.AccessibilityId("PasswordEntry"));
            SendKey("PasswordEntry", password);
            return this;
        }

        public DeleteSite TapDelete()
        {
            Tap("Delete");
            return this;
        }

        
        public static bool WasSuccessful;
        
        public DeleteSite ConfirmDelete()
        {
            var progressBar = Driver.FindXPathByText("Deleting");
            WasSuccessful = Driver.ElementNotPresent(progressBar);
            return this;
        }
    }
}