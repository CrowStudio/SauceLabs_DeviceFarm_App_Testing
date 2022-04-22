using DeviceFarm.Pages;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests
{
    [TestFixture]
    public class WelcomeTest : BaseFixture
    {
        [Test]
        public void LanguagePopup()
        {
            new Welcome()
                .TapLocalizationButton();
            
            new PopupDialog()
                .ConfirmPopupDialog();
            
            Assert.IsTrue(PopupDialog.Active, "NO PopupDialog present!");
        }

        [Test]
        public void SelectLanguageSvenska()
        {
            new Welcome()
                .TapLocalizationButton(); 
            
            new PopupDialog()
                .TapLanguage("sv")
                .TapSaveButton();
                
            new Welcome()
                .ConfirmLocaleSettings();
            
            Assert.AreEqual("SV", Welcome.PageLanguage, "Language \"SV\" was NOT set!");
        }
    }
}