using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.PageConfirmationTests
{
    [TestFixture]
    public class NewSitePageTest : BaseFixture
    {
        private const string NewSitePage = NewSite.PageId;
        
        [Test]
        public void ConfirmNewSitePage()
        {
            new Welcome()
                .TapLoginButton();

            new Login()
                .EnterEmail(UserMail)
                .EnterPassword(UserPassword)
                .TapLoginButton();

            new LeftHandMenu()
                .TapNewSystemButton();

            new NewSystem()
                .TapNewSystem();

            new NewSite()
                .ConfirmLoad(NewSitePage);

            Assert.IsTrue(NewSite.PageLoaded, "Page Id was NOT present!");
        }
    }
}