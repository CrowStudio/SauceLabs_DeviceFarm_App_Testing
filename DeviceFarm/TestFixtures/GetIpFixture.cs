using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace DeviceFarm.TestFixtures
{
    public class GetIpFixture : BaseFixture
    {
        private static string _ipAddress = "127.0.0.1";
        private static DriverWrapper _wrapper;
        
        [OneTimeSetUp]
        public void SetIp()
        {
            _wrapper = new DriverWrapper(
                new AndroidDriver<AppiumWebElement>(new Uri(LocalUrl), Capabilities.GetIp()));

            _ipAddress = _wrapper.GetDeviceIp();
            Console.WriteLine(_ipAddress);
            _wrapper.Quit();
        }
    }
}
