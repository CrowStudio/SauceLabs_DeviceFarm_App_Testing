using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.PageConfirmationTests
{
    [TestFixture]
    public class ChangeNamePageTest : BaseFixture
    {
        private const string ChangeNamePage = ChangeName.PageId;
        
        [Test]
        public void ConfirmChangeNamePage()
        {
            new Welcome()
                .TapLoginButton();

            new Login()
                .EnterEmail(UserMail)
                .EnterPassword(UserPassword)
                .TapLoginButton();

            new LeftHandMenu()
                .TapSystemSettingsByName("Allegra Geller")
                .TapChangeNameButton();

            new ChangeName()
                .ConfirmLoad(ChangeNamePage);

            Assert.IsTrue(ChangeName.PageLoaded, "Page Id was NOT present!");
        }
        
    }
}