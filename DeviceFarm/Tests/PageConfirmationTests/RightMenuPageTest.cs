using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.Pages.RightMenu;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.PageConfirmationTests
{
    [TestFixture]
    public class RightMenuPageTest : BaseFixture
    {
        [Test]
        public void ConfirmRightMenu()
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
                .TapRightMenu();

            new RightMenu()
                .GetMenuSystemName(SystemName);
           
            Assert.AreEqual(SystemName, RightMenu.SystemName, $"Right Menu for \"{SystemName}\" was NOT present!");
        }
    }
}