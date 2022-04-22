using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.UI;
using static System.Environment;

namespace DeviceFarm
{
    public class DriverWrapper
    {
        private readonly AppiumDriver<AppiumWebElement> _driver;
        
        public DriverWrapper(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
        }

        public void Quit() => _driver.Quit();

        public void ResetApp() => _driver.ResetApp();

        public string GetDeviceIp()
        {
            IJavaScriptExecutor adbGetIp = _driver;
            var ipAddress = (string) adbGetIp.ExecuteScript("mobile: shell", AdbGetIp());
            
            var index = ipAddress.IndexOf(NewLine);
            return ipAddress.Substring(index + 1);
        }

        private static Dictionary<string, object> AdbGetIp()
        {
            var argObject = new List<String>
            {
                "route", "|", "awk", "'{print $9}'"
            };
            
            var command = new Dictionary<string, object>
            {
                {"command", "ip"},
                {"args", argObject}
            };
            
            return command;
        }
        
        public string CaptureScreenshot()
        {
            return _driver.GetScreenshot().AsBase64EncodedString;
        }

        public void SaveScreenshot()
        {
            var fileName = TestContext.CurrentContext.Test.Name + ".jpg";
            var screenshot = CaptureScreenshot();
            var img = Convert.FromBase64String(screenshot);
            File.WriteAllBytes($"~/CapturedScreenshots/{fileName}", img);
        }

        public void StartScreenRecording()
        {
            _driver.StartRecordingScreen(
                AndroidStartScreenRecordingOptions.GetAndroidStartScreenRecordingOptions()
                    .WithTimeLimit(TimeSpan.FromSeconds(1000))
                    .EnableBugReport());
        }
        
        public void StopScreenRecording()
        {
            var fileName = TestContext.CurrentContext.Result.Outcome.Status + "_"
                              + TestContext.CurrentContext.Test.Name + ".mp4";
            var rawVideo = _driver.StopRecordingScreen();
            SaveScreenRecording(fileName, rawVideo);
        }

        private static void SaveScreenRecording(string fileName, string rawVideo)
        {
            var capturedVideo = Convert.FromBase64String(rawVideo);
            File.WriteAllBytes($"~/CapturedVideos/{fileName}", capturedVideo);
        }

        public void Tap(string id)
        {
            var element = FindElement(MobileBy.AccessibilityId(id)); 
            element.Click();
        }

        public void Tap(By by)
        {
            var element = FindElement(by);
            element.Click();
        }
        
        public void Tap(IWebElement element) => element.Click();

        public void TapBack() => _driver.Navigate().Back();

        public void TapBackAndroid() => ((AndroidDriver<AppiumWebElement>)_driver).PressKeyCode(AndroidKeyCode.Back);

        public void TapAndHold(IWebElement element)
        {
            var longTap = new TouchAction(_driver);
            longTap.LongPress(element).Perform();
        }

        public string GetClipboardAndroid()
        {
           return ((AndroidDriver<AppiumWebElement>)_driver).GetClipboardText();
        }

        public void SendKey(string id, string text)
        {
            var element = FindElement(MobileBy.AccessibilityId(id));
            element.SendKeys(text);
        }
        
        public void SendKey(By className, string text)
        {
            var element = FindElement(className);
            element.SendKeys(text);
        }

        public bool IsButtonEnabled(string id)
        {
            try
            {
               return _driver.FindElementByAccessibilityId(id).Enabled;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Element \"{id}\" was NOT enabled\n" + e);
                return false;
            }

        }

        public string GetTextByAccessibilityId(By id)
        {
            return FindElement(id).Text;
        }

        public By FindXPathByText(string text)
        {
            try
            {
                return By.XPath($"//*[@text = \"{text}\" or @label = \"{text}\" or @value = \"{text}\"]");
            }
            catch (Exception e)
            {
                Console.WriteLine($"XPath path with text: \"{text}\" was NOT found\n" + e);
                return null;
            }
        }
        
        public IWebElement FindElementByText(string text)
        {
            return FindElement(FindXPathByText(text));
        }

        private static By FindBy(string id)
        {
            return MobileBy.AccessibilityId(id);
        }
        
        
        private IWebElement _webElement;
        
        public IWebElement FindElement(string id)
        {
            var by = FindBy(id);

            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Element \"{id}\" was NOT found\n" + e);
                return null;
            }
        }
        
        public IWebElement FindElement(By by)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
                _webElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                var id = by.ToString();
                id = id[id.IndexOf('(')..].Replace("(", "").Replace(")", "");
                    
                Console.WriteLine($"Element \"{id}\" was NOT found\n" + e);
            }

            return _webElement;
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            }
            catch (Exception e)
            {
                var id = by.ToString();
                id = id[id.IndexOf('(')..].Replace("(", "").Replace(")", "");
                    
                Console.WriteLine($"Elements of \"{id}\" was NOT found\n" + e);
                return null;
            }
        }

        public bool ElementNotPresent(By by)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
            }
            catch (Exception e)
            {
                var id = by.ToString();
                id = id[id.IndexOf('(')..].Replace("(", "").Replace(")", "");
                Console.WriteLine($"Element \"{id}\" is still PRESENT\n" + e);
                
                return false;
            }
        }
    }
}