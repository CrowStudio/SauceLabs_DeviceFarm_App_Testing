using DeviceFarm.Pages;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.PageConfirmationTests
{
    [TestFixture]
    public class WelcomePageTest : BaseFixture
    {
        private const string WelcomePage = Welcome.PageId;
        
        [Test]
        public void ConfirmWelcomePage()
        {
            new Welcome()
                .ConfirmLoad(WelcomePage);
            
            Assert.IsTrue(Welcome.PageLoaded, "Page Id was NOT present!");
        }
    }
}