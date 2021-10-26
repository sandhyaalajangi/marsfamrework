using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.IO;
using static MarsFramework.Global.GlobalDefinitions;


namespace MarsFramework.Global
{

    class Base
    {
        String baseUrl = "http://localhost:5000/";


        #region To access Path from resource file


        
        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static String ExcelPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName + MarsResource.ExcelPath;
        public static String ShareSkillExcelPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName + MarsResource.ShareSkillExcelPath;
        public static String ManageListingsExcelPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName + MarsResource.ManageListingsExcelPath;
        public static string ScreenShotPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName + MarsResource.ScreenShotPath;
        public static string ReportPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName + MarsResource.ReportPath;
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;

        public static void ExtentReports()
        {
            Console.WriteLine("Reportpath " + ReportPath);
            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(MarsResource.ReportXMLPath);
        }
        #endregion


        #region setup and tear down
        [SetUp]
        [Obsolete]
        public void Inititalize()
        {

            switch (Browser)
            {

                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.driver = new ChromeDriver(@"C:\Users\eswar\Downloads\chromedriver_win32 (3)\");
                    GlobalDefinitions.driver.Manage().Window.Maximize();
                   // GlobalDefinitions.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(45);
                    GlobalDefinitions.driver.Navigate().GoToUrl(baseUrl);
                    break;

            }


            // Initialise Reports



            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                loginobj.LoginSteps();
            }
            else
            {
                SignUp obj = new SignUp();
                obj.register();
            }

        }


        [TearDown]
        public void TearDown()
        {
            // Screenshot
           Console.WriteLine("Base.ScreenShotPath" + Base.ScreenShotPath);
           String img = SaveScreenShotClass.SaveScreenshot(driver, "Report");
            //AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
           test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(img));
            // end test. (Reports)
            //extent.removetest(test);
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
           
            extent.Flush();
            // Close the driver :)            
           GlobalDefinitions.driver.Close();
            GlobalDefinitions.driver.Quit();
        }
       
         #endregion
     }




}


