using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using static MarsFramework.Global.GlobalDefinitions;
using OpenQA.Selenium.Support;
using RelevantCodes.ExtentReports.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Support.UI;
using AutoItX3Lib;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        //private object imageFilePath;

        private static string imageFilePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName + "\\ExcelData\\Wallpaper.jpg";

        //private static string imageFilePath = @"C:\sandhya\images\Wallpaper.jpg";

        [Obsolete]
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IList<IWebElement> ServiceTypeOptions { get; set; }

        //Select the radio button Hourlybasisservice type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")]
        private IWebElement Hourlybasisservicetype { get; set; }

        //select the radio button Hourlybasis service label
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/label")]
        private IWebElement ServiceTypeOptionsLabel { get; set; }

        //select the radio button oneoff service type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")]
        private IWebElement oneoffservicetype { get; set; }

        //select the radio button oneoff service label
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/label")]
        private IWebElement oneoffservicetypeLabel { get; set; }


        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Select the radio button On-site Location Type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")]
        private IWebElement Onsitetype { get; set; }


        //Select the radio button Onsite Location Label
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/label")]
        private IWebElement OnsitetypeLabel { get; set; }

        //Select the radio button   Online Location Type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")]
        private IWebElement Onlinetype { get; set; }


        //Select the radio button Online Location Label
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/label")]
        private IWebElement OnlineLabel { get; set; }




        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //click on checkbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input")]
        private IWebElement Checkboxfordays { get; set; }

        //click on checkbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[8]/div[1]/div/input")]
        private IWebElement SaturDay { get; set; }


        //click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //select Skill-Exchange Radiobutton type for Skill Trade option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")]
        private IWebElement SkillExchangetype { get; set; }

        //select Skill-Exchange Radiobutton label for Skill Trade option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/label")]
        private IWebElement SkillExchangeLabel { get; set; }

        //select Credit Radio button type for Skill Trade option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
        private IWebElement Credittype { get; set; }

        //select credit radio button label
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/label")]
        private IWebElement Creditlabel { get; set; }


        //enter the amount for Creditamountbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/input")]
        private IWebElement CreditAmountbox { get; set; }

        //Enter Skill Exchange tag
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchangeTag { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //select the radio button active type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")]
        private IWebElement Activetype { get; set; }

        //select theradio button active label
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/label")]
        private IWebElement ActiveLabel { get; set; }

        //select the radio button hidden type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input")]
        private IWebElement Hiddentype { get; set; }

        //select the radio button hidden label
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/label")]
        private IWebElement HiddenLabel { get; set; }

        //click on work samples file upload
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        private IWebElement WorkSampleFileUpload { get; set; }



        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //on alertbox
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement SucessOrFailure { get; set; }

        [Obsolete]
        internal void EnterShareSkill()
        {
            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.LinkText("Share Skill"), 30);

            //populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ShareSkillExcelPath, "ShareSkill");

            //Click on share skill Button
            ShareSkillButton.Click();

            //Click on title in textbox
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            GlobalDefinitions.wait(15);

            //Enter the Description in textBox
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //find xpath forCategory and assign input parameter level
            //select the drop down list
            //create select element object
            var selectElement = new SelectElement(CategoryDropDown);

            //select by text
            selectElement.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            GlobalDefinitions.wait(15);

            //find xpath for subCategory dropDown
            //Select the dropdown list
            //create select element object
            var SelectSubCategoryElement = new SelectElement(SubCategoryDropDown);
            //select by text
            SelectSubCategoryElement.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
            GlobalDefinitions.wait(15);

            //enter the tag name in textbox
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);
            GlobalDefinitions.wait(15);

            //select the Service type
            string Servicetype = (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType"));
            

            if (Servicetype.Equals(ServiceTypeOptionsLabel.Text)) 
             {
                Hourlybasisservicetype.Click();
             }
            else if (Servicetype.Equals(oneoffservicetypeLabel.Text))
             {
            oneoffservicetype.Click();
            }
            GlobalDefinitions.wait(15);


            //select the location type
            string Locationtype = (GlobalDefinitions.ExcelLib.ReadData(2, "LocationType"));
            if (Locationtype.Equals(OnsitetypeLabel.Text))
            {
                Onsitetype.Click();
            }
            else if (Locationtype.Equals(OnlineLabel.Text))
            {
                Onlinetype.Click();
            }
            GlobalDefinitions.wait(15);

            //update on End Date
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));
            Checkboxfordays.Click();

            //update Start time
           StartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));

            //update the Endtime
            EndTimeDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            
            //update for checkbox
            SaturDay.Click();
            GlobalDefinitions.wait(5);


            //select the Skill Tradetype
            string SkillTrade = (GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade"));

            if (SkillTradeOption.Equals(Creditlabel.Text))
            {
               Credittype.Click();
            }
           else if (SkillTradeOption.Equals(SkillExchangeLabel.Text))
            {
                SkillExchangetype.Click();
            }

           // CreditAmountbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
            GlobalDefinitions.wait(15);


            //Enter Skill Exchange Tags in text box
            SkillExchangeTag.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchangeTag.SendKeys(Keys.Enter);
            GlobalDefinitions.wait(15);

            //Add Work samples
            Console.WriteLine("Image File Path " + @imageFilePath);

            //upload image
            WorkSampleFileUpload.Click();

            AutoItX3 autoItX3 = new AutoItX3();
            autoItX3.WinActivate("Open");
            autoItX3.Send((string)@imageFilePath);
            autoItX3.Send("{ENTER}");



            //select the Active
            string Active = (GlobalDefinitions.ExcelLib.ReadData(2, "Active"));
            if (SkillTradeOption.Equals(ActiveLabel.Text))
            {
                Activetype.Click();
            }
            else if (SkillTradeOption.Equals(HiddenLabel.Text))
            {
                Hiddentype.Click();
            }
     

            //Click save button
            Save.Click();
            //GlobalDefinitions.wait(10);

            //Assertion
            //find xpath for success or failure message
           // GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//div[@class='ns-box-inner']"), 10);
           //var alerttext = SucessOrFailure.Text;


            //assert expected result = actual result
            //Assert.AreEqual("Service Listing Added successfully", alerttext);
      
        }


        internal void EditShareSkill()
        {
            //populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ShareSkillExcelPath, "UpdateShareSkill");

            //update the title in title box
            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.Name("title"), 30);
            Title.Clear();
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            GlobalDefinitions.wait(5);

            //update the Description in Textbox
            Description.Clear();
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            GlobalDefinitions.wait(5);

            //find xpath for category
            //select the dropdown list
            //create the select element object
            //create select element object
            var SelectElement = new SelectElement(CategoryDropDown);

            //select by text
            SelectElement.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            GlobalDefinitions.wait(5);


            //find xpath for subcategory
            //select the dropdown list
            //create the select element object
            //create select element object
            var SelectSubCategoryElement = new SelectElement(SubCategoryDropDown);

            //select by text
            SelectSubCategoryElement.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
            GlobalDefinitions.wait(5);

            // //enter the tag name in textbox
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);
            GlobalDefinitions.wait(15);

            //select the Service type
            string Servicetype = (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType"));
            if (ServiceTypeOptions.Equals(ServiceTypeOptionsLabel.Text))
            {
                Hourlybasisservicetype.Click();
            }
            else if (ServiceTypeOptions.Equals(oneoffservicetypeLabel.Text))
            {
                OnsitetypeLabel.Click();
            }
            GlobalDefinitions.wait(15);


            //select the location type
            string Locationtype = (GlobalDefinitions.ExcelLib.ReadData(2, "LocationType"));
            if (LocationTypeOption.Equals(OnsitetypeLabel.Text))
            {
                Onsitetype.Click();
            }
            else if (ServiceTypeOptions.Equals(OnlineLabel.Text))
            {
                Onlinetype.Click();
            }
            GlobalDefinitions.wait(15);

            //click on End Date
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));
            Checkboxfordays.Click();

            //select Start time
            StartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));

            //
            EndTimeDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));

            //select the Skill Tradetype
            string SkillTrade = (GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade"));
            if  (SkillTradeOption.Equals(SkillExchangeLabel.Text))
            {
                SkillExchangetype.Click();
            }
            else if (SkillTradeOption.Equals(Creditlabel.Text))
            {
                Credittype.Click();
            }
            GlobalDefinitions.wait(15);


            //Enter Skill Exchange Tags in text box
           // SkillExchangeTag.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
           // SkillExchangeTag.SendKeys(Keys.Enter);
          //  GlobalDefinitions.wait(15);

            //Add Work samples
           // Console.WriteLine("Image File Path" + @imageFilePath);

            //upload image
           // WorkSampleFileUpload.Click();

           // AutoItX3 autoItX3 = new AutoItX3();
           // autoItX3.WinActivate("Open");
           // autoItX3.Send((string)@imageFilePath);
           // autoItX3.Send("{ENTER}");



            //select the Active
            string Active = (GlobalDefinitions.ExcelLib.ReadData(2, "Active"));
            if (SkillTradeOption.Equals(ActiveLabel.Text))
            {
                Activetype.Click();
            }
            else if (SkillTradeOption.Equals(HiddenLabel.Text))
            {
                Hiddentype.Click();
            }
            GlobalDefinitions.wait(15);


            //Click save button
            Save.Click();
            GlobalDefinitions.wait(2);

            //Assertion
            //find xpath for success or failure message
           // GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//div[@class='ns-box-inner']"), 10);
            //var alerttext = SucessOrFailure.Text;

            //Console.WriteLine("alerttext " + alerttext);
            //assert expected result = actual result
           // Assert.AreEqual("Service Listing Added Successfully", alerttext);







        }
    }
}
