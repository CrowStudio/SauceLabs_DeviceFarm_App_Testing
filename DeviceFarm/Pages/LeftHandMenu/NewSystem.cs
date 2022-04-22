namespace DeviceFarm.Pages.LeftHandMenu
{
    public class NewSystem : BasePage
    {
        public const string PageId = "NewSystem";

        public NewSystem TapNewCustomer()
        {
            Tap("NewSite");
            return this;
        }
        
        public NewSystem TapNewSystem()
        {
            Tap("NewSite");
            return this;
        }
        
        public NewSystem TapRedeemSystemButton()
        {
            Tap("RedeemSite");
            return this;
        }
    }
}