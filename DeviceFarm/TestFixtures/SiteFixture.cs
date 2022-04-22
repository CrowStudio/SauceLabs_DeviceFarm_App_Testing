using System;
using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.Pages.RightMenu;
using NUnit.Framework;

namespace DeviceFarm.TestFixtures
{
    public class SiteFixture : BaseFixture
    {
        private const string NewOwnerEmail = "test@test.com",
                             NewOwnerPassword = "0000";

        protected new const string SystemName = "Gas";

        [SetUp]
        public override void SetUp()
        {
            StartApp();
            
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
            
            ResetApp();
            
            
            // Login as new Owner and Redeem System Code
            new Welcome()
                .TapLoginButton();
            
            new Login()
                .EnterEmail(NewOwnerEmail)
                .EnterPassword(NewOwnerPassword)
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
            
            StartScreenRecording();
        }
        
        [TearDown]
        public override void QuitApp()
        {
            try
            {
                StopScreenRecording();
            
                new Site()
                    .TapLeftHandMenu();
                
                new LeftHandMenu()
                    .TapSystemSettingsByName(SystemName)
                    .TapDeleteSystemButton();

                new DeleteSite()
                    .EnterPassword(NewOwnerPassword)
                    .TapDelete()
                    .ConfirmDelete();
                
                Assert.IsTrue(DeleteSite.WasSuccessful);
            
            }
            finally
            {
                StopApp();
            }
        }
    }
}