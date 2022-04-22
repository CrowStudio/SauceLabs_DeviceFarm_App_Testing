namespace DeviceFarm.Pages.LeftHandMenu
{
    public class TimeEventInfo : BasePage
    {
        public const string PageId = "TimeEventInfoPage";

        public TimeEventInfo TapIUnderstandButton()
        {
            Tap("Next");

            return this;
        }
    }
}