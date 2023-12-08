using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecflowAutomation.Hooks;

namespace SpecflowAutomation.Utilities
{
    public class Base 
    {
#pragma warning disable CS8618
        public static IWebDriver driver;
        private static ExtentReports extent;
        private static ExtentTest testreport;

        [SetUp]
        public void SetupAuction()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
        }
        public void LogScreenshot(string ScreenshotName)
        {
            string screenshotPath = CaptureScreenshot(ScreenshotName);
            if (testreport != null)
            {
                testreport.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }
        }

        public static string CaptureScreenshot(string screenshotName)
        {
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            string screenshotPath = Path.Combine("ScreenshotReport", $"{screenshotName}_{DateTime.Now:yyyyMMddHHmmss}.png");
            string fullPath = Path.Combine("C:\\ICProject\\AdvancedSpecFlow\\MarsAdvancedSpecflow\\SpecflowAutomation", screenshotPath);
#pragma warning disable
            screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);

            return fullPath;
        }
        [TearDown]
        public void TearDownAction()
        {
            driver.Quit();
        }
        

       
    }
}
