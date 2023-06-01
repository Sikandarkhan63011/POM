using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM
{
    [TestClass]
    public class ExecutionClass : BasePage
    {
        private TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            LogReport("Test Report");
            Console.WriteLine("AssemblyInitialize");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            ExtentFlush();
            Console.WriteLine("AssemblyCleanup");
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Console.WriteLine("ClassInitialize");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Console.WriteLine("ClassCleanup");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            exParentTest = extentReports.CreateTest(TestContext.TestName);
            NodeCreation(TestContext.TestName);
            ExecuteBrowser("Chrome");
            OpenURL("http://adactinhotelapp.com/");
            //driver.Url = "http://adactinhotelapp.com/";
        }

        [TestCleanup]
        public void TestCleanup()
        {
            CloseBrowser("q");
        }
    }
}
//public static ExtentReports extentReports;
//public static ExtentTest exParentTest;
//public static ExtentTest exChildTest;
//public static string dirpath;

//public static void LogReport(string testcase)
//{
//    extentReports = new ExtentReports();
//    dirpath = @"C:\TestExecutionReport\" + '_' + testcase;

//    ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);

//    htmlReporter.Config.Theme = Theme.Standard;

//    extentReports.AttachReporter(htmlReporter);
//}