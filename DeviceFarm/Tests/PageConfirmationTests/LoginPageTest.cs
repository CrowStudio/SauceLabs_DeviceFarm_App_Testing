using DeviceFarm.Pages;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.PageConfirmationTests
{
    [TestFixture]
    public class LoginPageTest : BaseFixture
    {
        private const string LoginPage = Login.PageId;
        
        [Test]
        public void ConfirmLoginPage()
        {
            new Welcome()
                .TapLoginButton();
            
            new Login()
                .ConfirmLoad(LoginPage);
            
            Assert.IsTrue(Login.PageLoaded, "Page Id was NOT present!");
        }
    }
}