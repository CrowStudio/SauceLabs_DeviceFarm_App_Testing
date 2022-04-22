namespace DeviceFarm.Pages
{
    public class RedeemLayout : BasePage
    {
        public const string PagId = "RedeemLayout";

        public RedeemLayout TapRedeemHere()
        {
            var redeemHere = Driver.FindXPathByText("Redeem here");
            Tap(redeemHere);
            return this;
        }
    }
}