using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.Pages.LeftHandMenu.UserSettings;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.LeftHandMenuTests.UserSettingsTests
{
    [TestFixture]
    public class ChangeUserNameTest : BaseFixture
    {
        private const string NewUserName = "Kiri Vinokur";
        
        [Test]
        public void ChangeUserName()
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
                .GetUserName()
                .TapName();

            new PopupDialog()
                .ClearTextFieldByContent(SitesSettings.UserName)
                .EnterNewText(NewUserName)
                .TapSaveButton();
                
            new SitesSettings()
                .GetUserName();
            
            Assert.AreEqual(NewUserName, SitesSettings.UserName, $"User name was NOT changed to\"{NewUserName}\"!");
        }

        [TearDown]
        public override void QuitApp()
        {
            StopScreenRecording();

            new SitesSettings()
                .TapName();
         
            new PopupDialog()
                .ClearTextFieldByContent(SitesSettings.UserName)
                .EnterNewText(SitesSettings.OriginalUserName)
                .TapSaveButton();
            
            new SitesSettings()
                .GetUserName();
            
            Assert.AreEqual(SitesSettings.OriginalUserName, SitesSettings.UserName, 
                $"User name was NOT changed to\"{SitesSettings.OriginalUserName}\"!");
            
            StopApp();
        }
    }
}