using System;

namespace DeviceFarm
{
    public class ServerOptions
    {
        private static string DataCenter => "ondemand.eu-central-1.saucelabs.com:443/wd/hub";
        private static string SauceUser => Environment.GetEnvironmentVariable("SAUCE_USERNAME");
        private static string SauceAccessKey => Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY");
        protected static string SauceLabsUrl => $"https://{SauceUser}:{SauceAccessKey}@{DataCenter}";
        protected static string LocalUrl => "http://127.0.0.1:4723";
    }
}