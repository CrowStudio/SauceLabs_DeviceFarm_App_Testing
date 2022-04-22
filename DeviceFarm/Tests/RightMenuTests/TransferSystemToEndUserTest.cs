using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.Pages.RightMenu;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.RightMenuTests
{
    [TestFixture]
    public class TransferSystemToEndUserTest : TransferSystemFixture
    {
        [Test]
        public void TransferToEndUser()
        {
            // Login as Installer and get Owner Code
            new Welcome()
                .TapLoginButton();
            
            new Login()
                .EnterEmail(InstallerMail)
                .EnterPassword(InstallerPassword)
                .TapLoginButton();
            
            new LeftHandMenu()
                .TapSystemByName(SystemName);

            new Site()
                .TapRightMenu();

            new RightMenu()
                .TapTransferToEndUser();

            new TransferToUser()
                .TapOwnerCode();

            new PopupDialog()
                .CopyOwnerCode(out var ownerCode, out var copiedCode)
                .TapCloseButton();
            
            Assert.AreEqual(ownerCode, copiedCode, "Expected code did NOT match copied code\n");

            ResetApp();
            
            
            // Login as new Owner and Redeem System Code
            new Welcome()
                .TapLoginButton();
            
            new Login()
                .EnterEmail(UserMail)
                .EnterPassword(UserPassword)
                .TapLoginButton();

            new LeftHandMenu()
                .TapNewSystemButton();
            
            new NewSystem()
                .TapRedeemSystemButton();

            new RedeemSite()
                .EnterSystemCode(copiedCode)
                .TapRedeemButton();

            new OwnerOverview()
                .ConfirmUser(UserName)
                .TapThisLookGood();

            new WelcomeOwner()
                .TapStartControlling();
            
            new Site()
                .GetSystemName(SystemName);
            
            Assert.AreEqual(SystemName, Site.Name, $"System \"{SystemName}\" was NOT imported");
        }
    }
}