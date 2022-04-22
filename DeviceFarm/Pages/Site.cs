namespace DeviceFarm.Pages
{
    public class Site : BasePage
    {
        public const string PageId = "SitePage";

        public Site TapLeftHandMenu()
        {
            Tap("LeftHandMenu");
            return this;
        }

        public Site TapRightMenu()
        {
            Tap("RightMenu");
            return this;
        }

        
        public static string Name;
        
        public Site GetSystemName(string systemName)
        {
            Name = Driver.FindElementByText(systemName).Text;
            return this;
        }
    }
}