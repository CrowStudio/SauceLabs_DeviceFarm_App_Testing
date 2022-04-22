using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace DeviceFarm
{
    public static class Capabilities
    {
        private static Dictionary<string, object> SauceLabsOptions()
        {
            var sauceOptions = new Dictionary<string, object>
            {
                {"appiumVersion", "1.20.1"},
                {"name", TestContext.CurrentContext.Test.Name},
                {"cacheId", "test-app-01"},
                {"noReset", "false"},
                {"newCommandTimeout", 90}
            };

            return sauceOptions;
        }

        public static AppiumOptions SauceLabsCapabilities()
        {
            var sauceLabsCapabilities = new AppiumOptions();
            sauceLabsCapabilities.AddAdditionalCapability("platformName", "Android");
            sauceLabsCapabilities.AddAdditionalCapability("appium:automationName", "UiAutomator2");
            sauceLabsCapabilities.AddAdditionalCapability("sauce:options", SauceLabsOptions());
            sauceLabsCapabilities.AddAdditionalCapability("appium:deviceName", ".*"); // Dynamic device allocation
            sauceLabsCapabilities.AddAdditionalCapability("appium:platformVersion", "12");
            sauceLabsCapabilities.AddAdditionalCapability("appium:name", TestContext.CurrentContext.Test.Name);
            sauceLabsCapabilities.AddAdditionalCapability("appium:app", "storage:filename=com.test.testdapp.apk");
            sauceLabsCapabilities.AddAdditionalCapability("appium:appPackage", "com.test.testdapp");
            sauceLabsCapabilities.AddAdditionalCapability("appium:appActivity", "testapp.MainActivity");
            sauceLabsCapabilities.AddAdditionalCapability("appium:autoGrantPermissions", "true");

            return sauceLabsCapabilities;
        }
        
        public static AppiumOptions LocalCapabilities()
        {
            var localCapabilities = new AppiumOptions();
            localCapabilities.AddAdditionalCapability("platformName", "Android");
            localCapabilities.AddAdditionalCapability("appium:automationName", "UiAutomator2");
            localCapabilities.AddAdditionalCapability("appium:appiumVersion", "2.0.0-beta.25");
            //localCapabilities.AddAdditionalCapability("appium:deviceName", "Pixel_5_API_30");
            //localCapabilities.AddAdditionalCapability("appium:udid", "emulator-5554");
            localCapabilities.AddAdditionalCapability("appium:deviceName", "*"); // Replace * with device name
            localCapabilities.AddAdditionalCapability("appium:udid", "*"); // Replace * with device udid
            localCapabilities.AddAdditionalCapability("appium:name", TestContext.CurrentContext.Test.Name);
            localCapabilities.AddAdditionalCapability("appium:app", "~/app/com.test.testdapp.apk");
            localCapabilities.AddAdditionalCapability("appium:appPackage", "com.test.testdapp");
            localCapabilities.AddAdditionalCapability("appium:appActivity", "testapp.MainActivity");
            localCapabilities.AddAdditionalCapability("appium:autoGrantPermissions", "true");
            //localCapabilities.AddAdditionalCapability("appium:fullReset", "true");

            return localCapabilities;
        }
        
        public static AppiumOptions GetIp()
        {
            var getIpCapabilities = new AppiumOptions();
            getIpCapabilities.AddAdditionalCapability("platformName", "Android");
            getIpCapabilities.AddAdditionalCapability("appium:automationName", "UiAutomator2");
            getIpCapabilities.AddAdditionalCapability("appium:appiumVersion", "2.0.0-beta.25");
            //getIpCapabilities.AddAdditionalCapability("appium:deviceName", "Pixel_5_API_30");
            //getIpCapabilities.AddAdditionalCapability("appium:udid", "emulator-5554");
            getIpCapabilities.AddAdditionalCapability("appium:deviceName", "*"); // Replace * with device name
            getIpCapabilities.AddAdditionalCapability("appium:udid", "*"); // Replace * with device udid

            return getIpCapabilities;
        }
    }
}
