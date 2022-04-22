using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace DeviceFarm
{
    public class AppInitializer : ServerOptions
    {
        private static DriverWrapper _wrapper;

        public static DriverWrapper Wrapper()
        {
            return _wrapper;
        }

        protected static void StartApp()
        {
            _wrapper?.Quit();
            _wrapper = new DriverWrapper(
                new AndroidDriver<AppiumWebElement>(new Uri(LocalUrl), Capabilities.LocalCapabilities()));
        }

        protected static void StopApp()
        {
            _wrapper.Quit();
        }

        protected static void ResetApp()
        {
            _wrapper.ResetApp();
        }
        
        protected static void StartScreenRecording()
        {
            _wrapper.StartScreenRecording();
        }
        
        protected static void StopScreenRecording()
        {
            _wrapper.StopScreenRecording();
        }
    }
}