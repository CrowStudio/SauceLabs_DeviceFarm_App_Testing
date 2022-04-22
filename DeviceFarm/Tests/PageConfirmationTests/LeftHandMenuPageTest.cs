using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.PageConfirmationTests
{
    [TestFixture]
    public class LeftHandMenuPageTest : BaseFixture
    {
        private const string LeftHandMenuPage = LeftHandMenu.PageId;
        
        [Test]
        public void ConfirmLeftHandMenuPage()
        {
            new Welcome()
                .TapLoginButton();
            
            new Login()
                .EnterEmail(UserMail)
                .EnterPassword(UserPassword)
                .TapLoginButton();
            
            new LeftHandMenu()
                .ConfirmLoad(LeftHandMenuPage);
           
            Assert.IsTrue(LeftHandMenu.PageLoaded, "Page Id was NOT present!");
        }
    }
}