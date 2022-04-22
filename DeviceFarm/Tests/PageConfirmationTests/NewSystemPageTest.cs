using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.PageConfirmationTests
{
    [TestFixture]
    public class NewSystemPageTest : BaseFixture
    {
        private const string NewSystemPage = NewSystem.PageId;
        
        [Test]
        public void ConfirmNewSystemPage()
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
                .ConfirmLoad(NewSystemPage);
            
            Assert.IsTrue(NewSystem.PageLoaded, "Page Id was NOT present!");
        }
    }
}