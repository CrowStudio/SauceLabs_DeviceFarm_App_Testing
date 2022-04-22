namespace DeviceFarm.Pages.RightMenu
{
    public class Device : BasePage
    {
        public const string PageId = "AddDevice";

        public static bool DeviceListAvailable;

        public Device ConfirmDeviceList()
        {
            DeviceListAvailable = Driver.FindElement("DeviceList").Displayed;
            return this;
        }
    }
}