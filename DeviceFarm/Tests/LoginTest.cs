using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.Pages.LeftHandMenu.UserSettings;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests
{
    [TestFixture]
    public class LoginTest : BaseFixture
    {
        private const string WelcomePage = Welcome.PageId;

        [Test]
        public void NoLoginButton()
        {
            new Welcome()
                .TapLoginButton();
            
            new Login()
                .EnterEmail(UserMail)
                .ConfirmLoginButton();
            
            Assert.IsFalse(Login.ButtonActive, "Login Button was ACTIVE");
        }
        
        [Test]
        public void LoginButtonActive()
        {
            new Welcome()
                .TapLoginButton();
            
            new Login()
                .EnterEmail(UserMail)
                .EnterPassword(UserPassword)
                .ConfirmLoginButton();
            
            Assert.IsTrue(Login.ButtonActive, "Login Button was NOT active");
        }
        
        [Test]
        public void LoginAndLogout()
        {
            new Welcome()
                .TapLoginButton();
            
            new Login()
                .EnterEmail(UserMail)
                .EnterPassword(UserPassword)
                .TapLoginButton();
            
            new LeftHandMenu()
                .TapSettingsButton();
            
            new SitesSettings()
                .TapLogOutButton();
                
            new PopupDialog()
                .TapOkButton();
            
            new Welcome()
                .ConfirmLoad(WelcomePage);
            
            Assert.IsTrue(Welcome.PageLoaded, "Page Id was NOT present!");
        }
        
        
        private const string MailAddress = "1234@test.com",
                             Password = "1111";
        
        [Test]
        public void IncorrectLoginCredentials()
        {
            new Welcome()
                .TapLoginButton();

            new Login()
                .EnterEmail(MailAddress)
                .EnterPassword(Password)
                .TapLoginButton();

            new PopupDialog()
                .ConfirmErrorMessage();
            
            Assert.AreEqual(PopupDialog.ExpectedErrorMessage, PopupDialog.ErrorMessage, 
                $"Error message did NOT match expected string\n");
        }

        [Test]
        public void ClosePopupForIncorrectLogin()
        {
            new Welcome()
                .TapLoginButton();

            new Login()
                .EnterEmail(MailAddress)
                .EnterPassword(Password)
                .TapLoginButton();
                
            new PopupDialog()
                .ConfirmErrorMessage()
                .TapOkButton();
            
            Assert.IsTrue(PopupDialog.Closed, "PopupDialog was STILL present!");
        }
    }
}