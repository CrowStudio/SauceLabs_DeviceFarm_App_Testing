namespace DeviceFarm.Pages.LeftHandMenu
{
    public class WelcomeOwner : BasePage
    {
        public const string PageId = "WelcomeOwner";

        public WelcomeOwner TapStartControlling()
        {
            Tap("Done");
            return this;
        }
        
    }
}