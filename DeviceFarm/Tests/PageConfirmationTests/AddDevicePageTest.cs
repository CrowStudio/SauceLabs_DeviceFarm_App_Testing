using DeviceFarm.Pages;
using DeviceFarm.Pages.RightMenu;
using DeviceFarm.TestFixtures;
using NUnit.Framework;

namespace DeviceFarm.Tests.PageConfirmationTests
{
    [TestFixture]
    public class AddDevicePageTest : SiteFixture
    {
        [Test]
        public void AddDevice()
        {
            new Site()
                .TapRightMenu();

            new RightMenu()
                .TapAddDevice();

            new Device()
                .ConfirmDeviceList()
                .ConfirmLoad(Device.PageId)
                .TapBack();

            Assert.IsTrue(Device.PageLoaded, "Page Id was NOT present!");
        }
    }
}