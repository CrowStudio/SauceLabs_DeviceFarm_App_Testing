using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.PageConfirmationTests
{
    [TestFixture]
    public class SitePageTest : BaseFixture
    {
        private const string SitePage = Site.PageId;
        
        [Test]
        public void ConfirmSitePage()
        {
            new Welcome()
                .TapLoginButton();
            
            new Login()
                .EnterEmail(UserMail)
                .EnterPassword(UserPassword)
                .TapLoginButton();
            
            new LeftHandMenu()
                .TapSystemByName(SystemName);
            
            new Site()
                .GetSystemName(SystemName)
                .ConfirmLoad(SitePage);
            
            Assert.AreEqual(SystemName, Site.Name, $"System \"{SystemName}\" was NOT imported");
            Assert.IsTrue(Site.PageLoaded, "Page Id was NOT present!");
        }
    }
}