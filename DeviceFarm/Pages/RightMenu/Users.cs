namespace DeviceFarm.Pages.RightMenu
{
    public class Users : BasePage
    {
        public const string PageId = "Users";

        public Users TapInviteUsers()
        {
            Tap("InviteUsers");
            return this;
        }
    }
}