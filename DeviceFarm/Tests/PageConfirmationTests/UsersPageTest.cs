using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.Pages.RightMenu;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.PageConfirmationTests
{
    [TestFixture]
    public class UsersPageTest : BaseFixture
    {
        private const string UsersPage = Users.PageId;

        [Test]
        public void ConfirmUsersPage()
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
                .TapUsers();

            new Users()
                .ConfirmLoad(UsersPage);

            Assert.IsTrue(Users.PageLoaded, "Page Id was NOT present!");
        }
    }
}
