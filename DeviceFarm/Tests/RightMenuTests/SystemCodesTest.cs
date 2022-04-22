using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.Pages.RightMenu;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.RightMenuTests
{
    [TestFixture]
    public class SystemCodesTest : BaseFixture
    {
        public static string OwnerCode,
                             UserCode,
                             InstallerCode,
                             CopiedCode;

        private const string OwnerMail = UserMail,
                             OwnerPassword = UserPassword;
        
        private new const string SystemName = "D\'Arcy Nader";

        [Test]
        public void ConfirmCopiedOwnerCode()
        {
            new Welcome()
                .TapLoginButton();
            
            new Login()
                .EnterEmail(OwnerMail)
                .EnterPassword(OwnerPassword)
                .TapLoginButton();
            
            new LeftHandMenu()
                .TapSystemByName(SystemName);

            new Site()
                .TapRightMenu();

            new RightMenu()
                .TapUsers();

            new Users()
                .TapInviteUsers();

            new SystemCodes()
                .CopyOwnerCode();
            
            Assert.AreEqual(OwnerCode, CopiedCode, "Expected code did NOT match copied code\n");
        }
        
        [Test]
        public void ConfirmCopiedUserCode()
        {
            new Welcome()
                .TapLoginButton();
            
            new Login()
                .EnterEmail(OwnerMail)
                .EnterPassword(OwnerPassword)
                .TapLoginButton();
            
            new LeftHandMenu()
                .TapSystemByName(SystemName);

            new Site()
                .TapRightMenu();

            new RightMenu()
                .TapUsers();

            new Users()
                .TapInviteUsers();

            new SystemCodes()
                .CopyUserCode();
            
            Assert.AreEqual(UserCode, CopiedCode, "Expected code did NOT match copied code\n");
        }
        
        [Test]
        public void ConfirmCopiedInstallerCode()
        {
            new Welcome()
                .TapLoginButton();
            
            new Login()
                .EnterEmail(OwnerMail)
                .EnterPassword(OwnerPassword)
                .TapLoginButton();
            
            new LeftHandMenu()
                .TapSystemByName(SystemName);

            new Site()
                .TapRightMenu();

            new RightMenu()
                .TapUsers();

            new Users()
                .TapInviteUsers();

            new SystemCodes()
                .CopyInstallerCode();
            
            Assert.AreEqual(InstallerCode, CopiedCode,"Expected code did NOT match copied code\n");
        }
    }
}