using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    class SignIn
    {
        [System.Obsolete]
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {
           // System.Console.WriteLine(Base.ExcelPath)
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "signIn");



            //navigate to url
            Global.GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            //Click on join button
            SignIntab.Click();

            //Enter Email
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));

            //enter Password
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //click on login button
            LoginBtn.Click();
        }
    }

}