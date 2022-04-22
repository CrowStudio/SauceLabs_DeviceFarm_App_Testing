using OpenQA.Selenium.Appium;

namespace DeviceFarm.Pages
{
    public class Login : BasePage
    {
        public const string PageId = "LoginPage";

        public Login TapLoginButton()
        {
            Tap("LogIn");
            return this;
        }
        
        public Login EnterEmail(string email)
        {
            var emailField = Driver.FindElement(MobileBy.AccessibilityId("EmailEntry"));
            if (!string.IsNullOrEmpty(emailField.Text)) emailField.Clear();
            SendKey("EmailEntry",email);
            return this;
        }

        public Login EnterPassword(string password)
        {
            Driver.FindElement(MobileBy.AccessibilityId("PasswordEntry"));
            SendKey("PasswordEntry",password);
            return this;
        }

        
        public static bool ButtonActive;
        
        public Login ConfirmLoginButton()
        {
            Driver.FindElement(MobileBy.AccessibilityId("LogIn"));
            ButtonActive = Driver.IsButtonEnabled("LogIn");
            return this;
        }
    }
}