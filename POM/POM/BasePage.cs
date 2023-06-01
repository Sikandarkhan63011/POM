using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V111.DOM;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using System;
using System.Threading;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace POM
{
    public class BasePage
    {
        public static IWebDriver driver;
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        //public static string currentDateAndTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        public static string dirpath = "C:\\TestExecutionReport\\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "\\";
        

        public IWebDriver SeleniumInit(string browser)
        {
            driver = null;
            if (browser == "Chrome")
            {
                return driver = new ChromeDriver();
            }
            else if (browser == "FireFox")
            {
                return driver = new FirefoxDriver();
            }
            else if (browser == "IE")
            {
                return driver = new InternetExplorerDriver();
            }
            else if (browser == "Edge")
            {
                return driver = new EdgeDriver();
            }
            else if (browser == "Safari")
            {
                return driver = new SafariDriver();
            }
            return driver;
        }
        public void ExecuteBrowser(string browser)
        {
            SeleniumInit(browser);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }
        public void OpenURL(string url)
        {
            try
            {
                driver.Url = url;
                TakeScreenShot(Status.Pass, "URL Open Successfully");
            }
            catch (Exception ex)
            {
                TakeScreenShot(Status.Fail, "This site can't be reached");
            }
        }
        public IWebDriver CloseBrowser(string X)
        {
            if (X == "c")
            {
                driver.Close();
            }
            else if (X == "q")
            {
                driver.Quit();
            }
            else if (X == "d")
            {
                driver.Dispose();
            }
            return driver;
        }
        public void EnterText(By by, string val)
        {
            try
            {
                driver.FindElement(by).SendKeys(val);
                TakeScreenShot(Status.Pass, "Test Successful" + val);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Action Unsuccessful" + ex.Message);
                TakeScreenShot(Status.Fail, "Action Unsuccessful : " + ex.ToString());
            }
        }
        public void Clear(By by)
        {
            driver.FindElement(by).Clear();
        }
        public void Click(By by)
        {
            try
            {
                driver.FindElement(by).Click();
                TakeScreenShot(Status.Pass, "Click Operation Passed" + by);
            }
            catch(Exception ex)
            {
                TakeScreenShot(Status.Fail, "Click Operation Failed : " + ex.ToString());
            }
        }
        public void Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }
        public void TakeScreenShot(Status status, string stepDetail)
        {
            //string path = "C:\\Users\\Hp\\source\\repos\\POM\\POM\\bin\\Debug\\Screenshots\\Screenshot";
            string path = dirpath + "SS_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(path + ".png", ScreenshotImageFormat.Png);
            exChildTest.Log(status, stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(path + ".png").Build());
        }
        public static void LogReport(string testcase)
        {
            //dirpath = @"C:\\TestExecutionReport\\" + '_' + testcase;
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);

            #region LogReport
            htmlReporter.Config.DocumentTitle = "Automation Test Project";
            //htmlReporter.Config.ReportName = "TestReport" + currentDateAndTime;
            htmlReporter.Config.Theme = Theme.Dark;

            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);

            extentReports.AddSystemInfo("AUT", "Hotel Adactin");
            extentReports.AddSystemInfo("Enviorment", "QA");
            extentReports.AddSystemInfo("Machine", Environment.MachineName);
            extentReports.AddSystemInfo("OS", Environment.OSVersion.VersionString);
            #endregion
        }
        public void NodeCreation(string methodName)
        {
            exChildTest = exParentTest.CreateNode(methodName);
        }
        public static void ExtentFlush()
        {
            extentReports.Flush();
        }
    }
}
