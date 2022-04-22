using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.LeftHandMenuTests
{
    [TestFixture]
    public class NewSiteTest : BaseFixture
    {
        [Test]
        public void NoAddButton()
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
                .ConfirmAddButton();
            
            Assert.IsFalse(NewSite.ActiveAddButton, "Add Button Button was ACTIVE");
        }
        
        [Test]
        public void ConfirmAddButton()
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
                .EnterSystemName(SystemName)
                .ConfirmAddButton();
            
            Assert.IsTrue(NewSite.ActiveAddButton, "Add Button was NOT active");
        }
    }
}