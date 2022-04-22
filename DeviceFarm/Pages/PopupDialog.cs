using DeviceFarm.Pages.RightMenu;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace DeviceFarm.Pages
{
    public class PopupDialog : BasePage
    {
        public const string PageId = "PopupDialog";
        
        public static bool Active;

        public PopupDialog TapLanguage(string lang)
        {
            Tap(lang);
            return this;
        }
        
        public PopupDialog ConfirmPopupDialog()
        {
            Active = Driver.FindElement(MobileBy.AccessibilityId("PopupDialog")).Displayed;
            return this;
        }
        
        
        public const string ExpectedErrorMessage = "The username or password you provided does not match. Please try again.";
        public static string ErrorMessage; 
        
        public PopupDialog ConfirmErrorMessage()
        {
            try
            {
                Driver.FindElement(MobileBy.AccessibilityId("PopupDialog"));
                ErrorMessage = Driver.FindElementByText(ExpectedErrorMessage).Text;
            }
            catch
            {
            }

            return this;
        }

        public PopupDialog TapOkButton()
        {
            Tap("Ok");
            NoPopupDialog();
            return this;
        }
        
        public PopupDialog TapSaveButton()
        {
            Tap("Save");
            NoPopupDialog();
            return this;
        }
        
        public PopupDialog TapCancelButton()
        {
            Tap("Cancel");
            NoPopupDialog();
            return this;
        }

        public PopupDialog CopyOwnerCode(out string ownerCode, out string copiedCode)
        {
            Tap("Copy");
            ownerCode = GetCodeFromPopup("Code");
            copiedCode = Driver.GetClipboardAndroid();
            return this;
        }

        private static string GetCodeFromPopup(string id) => Driver.FindElement(MobileBy.AccessibilityId(id)).Text;

        public PopupDialog TapCloseButton()
        {
            Tap("Close");
            NoPopupDialog();
            return this;
        }
        
        
        public static bool Closed;
        
        private static void NoPopupDialog()
        {
            Closed = Driver.ElementNotPresent(MobileBy.AccessibilityId("PopupDialog"));
        }
        
        public PopupDialog ClearTextFieldByContent(string textContent)
        {
            Driver.FindElement(By.ClassName("EditText"));
            var entry = Driver.FindElementByText(textContent);
            entry.Clear();
            return this;
        }

        public PopupDialog EnterNewText(string newText)
        {
            SendKey(By.ClassName("EditText"), newText);
            return this;
        }
    }
}