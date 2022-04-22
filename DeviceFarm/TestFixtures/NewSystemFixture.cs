using DeviceFarm.Pages;
using DeviceFarm.Pages.LeftHandMenu;
using NUnit.Framework;

namespace DeviceFarm.TestFixtures
{
    public class NewSystemFixture : BaseFixture
    {
        protected new const string SystemName = "Ted Pikul";
        
        [TearDown]
        public override void QuitApp()
        {
            StopScreenRecording();
            
            new Site()
                .TapLeftHandMenu();
            
            new LeftHandMenu()
                .TapSystemSettingsByName(SystemName)
                .TapDeleteSystemButton();

            new DeleteSite()
                .EnterPassword(UserPassword)
                .TapDelete()
                .ConfirmDelete();
            
            Assert.IsTrue(DeleteSite.WasSuccessful);
            
            StopApp();
        }
    }
}