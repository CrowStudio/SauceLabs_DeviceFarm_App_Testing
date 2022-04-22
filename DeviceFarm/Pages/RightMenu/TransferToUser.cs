namespace DeviceFarm.Pages.RightMenu
{
    public class TransferToUser: BasePage
    {
        public const string PageId = "TransferToUser";
        
        public static string CopiedCode, OwnerCode;

        public TransferToUser TapOwnerCode()
        {
            Tap("SiteCode");
            return this;
        }
    }
}