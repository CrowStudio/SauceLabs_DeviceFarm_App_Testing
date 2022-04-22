using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.LeftHandMenuTests
{
    [TestFixture]
    public class ChangeSystemNameTest : BaseFixture
    {
        private const string OriginalSystemName = SystemName,
                             NewSystemName = "Ted Pikul";

        [Test]
        public void ChangeSharedSystemName()
        {
            new Welcome()
                .TapLoginButton();

            new Login()
                .EnterEmail(UserMail)
                .EnterPassword(UserPassword)
                .TapLoginButton();

            new LeftHandMenu()
                .TapSystemSettingsByName(OriginalSystemName)
                .TapChangeNameButton();

            new ChangeName()
                .TapSharedSystemName();

            new PopupDialog()
                .ClearTextFieldByContent(OriginalSystemName)
                .EnterNewText(NewSystemName)
                .TapSaveButton();

            new ChangeName()
                .TapSaveButton();

            new Site()
                .TapLeftHandMenu();

            new LeftHandMenu()
                .ConfirmSystemName(NewSystemName);

            Assert.AreEqual(NewSystemName, LeftHandMenu.SystemNameChanged, $"User name was NOT restored to \"{NewSystemName}\"!");
            
        }
        
        [TearDown]
        public override void QuitApp()
        {
            StopScreenRecording();

            new LeftHandMenu()
                .TapSystemSettingsByName(NewSystemName)
                .TapChangeNameButton();

            new ChangeName()
                .TapSharedSystemName();

            new PopupDialog()
                .ClearTextFieldByContent(NewSystemName)
                .EnterNewText(OriginalSystemName)
                .TapSaveButton();

            new ChangeName()
                .TapSaveButton();

            new Site()
                .TapLeftHandMenu();

            new LeftHandMenu()
                .ConfirmSystemName(OriginalSystemName);
            
            Assert.AreEqual(OriginalSystemName, LeftHandMenu.SystemNameChanged, $"User name was NOT restored to \"{OriginalSystemName}\"!");
            
            StopApp();
        }
    }
}