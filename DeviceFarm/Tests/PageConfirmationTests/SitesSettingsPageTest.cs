using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.Pages.LeftHandMenu.UserSettings;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.PageConfirmationTests
{
    [TestFixture]
    public class SitesSettingTest : BaseFixture
    {
        private const string SitesSettingPage = SitesSettings.PageId;
        
        [Test]
        public void ConfirmSiteSettingPage()
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
                .ConfirmLoad(SitesSettingPage);
            
            Assert.IsTrue(SitesSettings.PageLoaded, "Page Id was NOT present!");
        }
    }
}