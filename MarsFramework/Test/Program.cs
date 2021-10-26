using MarsFramework.Pages;
using NUnit.Framework;
using MarsFramework.Global;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test, Order(1)]
           
            public void Test_CreateShareSkill()
            {

                //start the reports
                ExtentReports();
                test = extent.StartTest("Create ShareSkill");
                test.Log(LogStatus.Info, "ShareSkills");

                //taking ScreenShots of adding skills
                SaveScreenShotClass.SaveScreenshot(driver, "ShareSkill");

                //create service details
                ShareSkill ShareSkillObj = new ShareSkill();
                ShareSkillObj.EnterShareSkill();

               //Listings 
                ManageListings manageListingsObj = new ManageListings();
                manageListingsObj.Listings();

                //assert create share skill
                Assertlistings(Base.ShareSkillExcelPath, "ShareSkill");

            }



            [Test, Order(2)]
            public void Test_EditShareSkill()
            {
                //start the reports
                ExtentReports();
                test = extent.StartTest("Edit ShareSkill");
                test.Log(LogStatus.Info, "ShareSkills");


                //taking ScreenShots of adding skills
                SaveScreenShotClass.SaveScreenshot(driver, "ShareSkill");

                //Update service details
                //Listing
                ManageListings manageListingsObj = new ManageListings();
                manageListingsObj.EditShareSkillFromListings();

                //assert update share skill
                manageListingsObj.Listings();
                Assertlistings(Base.ShareSkillExcelPath, "UpdateShareSkill");



            }


            [Test, Order(3)]
            public void Test_DeleteShareSkill()
            {
                //start the reports
                ExtentReports();
                test = extent.StartTest("Delete ShareSkill");
                test.Log(LogStatus.Info, "ShareSkills");


                //taking ScreenShots of adding skills
                SaveScreenShotClass.SaveScreenshot(driver, "ShareSkill");

                //Update service details
                //Listing
                ManageListings manageListingsObj = new ManageListings();
                manageListingsObj.DeleteShareSkillFromListings();
               
                //assert update share skill
                manageListingsObj.Listings();
                //AssertDelete();

            }
            private void Assertlistings(string Filename, string name)
            {
                var categoryexceldata = GlobalDefinitions.ExcelLib.ReadData(2, "Category");
                var titleexceldata = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                var descriptionexceldata = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
                var servicetypeexceldata = GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType");

                //xpath for manage listing table
                var elemTable = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table"));

                //fetch all row of the table
                List<IWebElement> listTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));
                string strRowData = "";

                // Transverse a each row
                foreach (var elemTr in listTrElem)
                {

                    //fetch all the cloumns of the particular row
                    List<IWebElement> listTdElem = new List<IWebElement>(elemTable.FindElements(By.TagName("td")));
                    if (listTdElem.Count > 0)
                    {
                        // Transverse each column
                        foreach (var elemTd in listTdElem)
                        {
                            //  "\t\t" is used for tab space between two text
                            strRowData = strRowData + elemTd.Text + "\t\t";
                            Console.WriteLine(elemTd.Text);
                        }
                        string CategoryTextListings = listTdElem[1].Text;
                        string TitleTextListings = listTdElem[1].Text;
                        string DescriptionTextListings = listTdElem[1].Text;
                        string ServiceTypeTextListings = listTdElem[1].Text;
                        Assert.AreEqual(categoryexceldata, CategoryTextListings);
//                        Assert.AreEqual(titleexceldata, TitleTextListings);
                       // Assert.AreEqual(descriptionexceldata, DescriptionTextListings);
                        //Assert.True(servicetypeexceldata.Contains(ServiceTypeTextListings));

                    }
                    else
                    {
                        //To print the data into the console
                        Console.WriteLine("This is Header Row");
                        Console.WriteLine(listTrElem[0].Text.Replace(" ", "\t\t"));


                    }
                }
            }

            //private void AssertDelete()
            //{
            //    //make sure the following message is displayed

            //    var NoListingsMessage = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/h3"));
            //    Assert.AreEqual("You do not have any service listings!", NoListingsMessage.Text);
                    

            //}








        }
    }

}