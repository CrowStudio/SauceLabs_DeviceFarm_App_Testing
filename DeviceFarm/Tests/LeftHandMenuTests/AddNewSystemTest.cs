using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.LeftHandMenuTests
{
    [TestFixture]
    public class AddNewSystemTest : NewSystemFixture
    {
        [Test]
        public void AddNewSystem()
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
                .TapAddButton();
            
            new Site()
                .GetSystemName(SystemName);
            
            Assert.AreEqual(SystemName, Site.Name, $"System \"{SystemName}\" was NOT created!");
        }
    }
}