using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.LeftHandMenuTests
{
    [TestFixture]
    public class ChangeNicknameTest : BaseFixture
    {
        private const string OriginalSystemName = SystemName,
                             NewNickname = "Demoness";
        
        [Test]
        public void ChangeSystemNickname()
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
                .TapPersonalNickname();

            new PopupDialog()
                .EnterNewText(NewNickname)
                .TapSaveButton();

            new ChangeName()
                .TapSaveButton();

            new Site()
                .TapLeftHandMenu();

            new LeftHandMenu()
                .ConfirmSystemName(NewNickname);

            Assert.AreEqual(NewNickname, LeftHandMenu.SystemNameChanged, $"User name was NOT changed to \"{NewNickname}\"!");
        }

        [TearDown]
        public override void QuitApp()
        {
            StopScreenRecording();
            
            new LeftHandMenu()
                .TapSystemSettingsByName(NewNickname)
                .TapChangeNameButton();
            
            new ChangeName()
                .TapPersonalNickname();
            
            new PopupDialog()
                .ClearTextFieldByContent(NewNickname)
                .EnterNewText("")
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