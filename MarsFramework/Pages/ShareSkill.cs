

using AutoItX3Lib;
using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
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
        //[FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[@class='ReactTags__tags']/div[@class='ReactTags__selected']/div[@class='ReactTags__tagInput']/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.XPath, Using = "//div[4]//span[1]//span[1]//span[1]//span[1]//span[1]")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "end")]
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

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        internal void ShareNewSkill()
        {

            // read data from exerl
            ExcelLib.PopulateInCollection(@"C:\Users\PIPER\source\repos\piper9797\Skillwap_Test2\MarsFramework\ExcelData\TestDataShareSkill.xlsx", "ShareSkill");

            Thread.Sleep(5000);

            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, "XPath", "//a[@href='/Home/ServiceListing']", 5);

            // click the share skill btn
            ShareSkillButton.Click();
            //  GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, "XPath", "//input[contains(@name,'title')]", 5);
            Thread.Sleep(2000);
            // fill in details
            //skill
            Title.SendKeys(ExcelLib.ReadData(2, "Title"));
            Description.SendKeys(ExcelLib.ReadData(2, "Description"));
            //category
            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, "XPath", "//select[contains(@name,'categoryId')]", 5);
            Thread.Sleep(800);
            //CategoryDropDown.Click();
            SelectElement category = new SelectElement(CategoryDropDown);
            category.SelectByValue("8");

            Thread.Sleep(100);
            SelectElement category2 = new SelectElement(SubCategoryDropDown);
            category2.SelectByValue("4");

            Thread.Sleep(100);
            //tags
            Tags.SendKeys(ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);
            Assert.IsNotEmpty(GlobalDefinitions.driver.FindElement(By.XPath("(//span[contains(@class,'ReactTags__tag')])[1]")).Text);
            //service type
            Global.GlobalDefinitions.driver.FindElement(By.XPath("(//input[contains(@name,'serviceType')])[2]")).Click();
            //skip location type
            //click week

            Thread.Sleep(2000);
            Global.GlobalDefinitions.driver.FindElement(By.LinkText("Week")).Click();
            //choose the time table
            // (1)double click 
            Actions action = new Actions(GlobalDefinitions.driver);
            // Thread.Sleep(600);
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "Xpath", "//tr[6]//td[7]", 5);
            IWebElement timetable = GlobalDefinitions.driver.FindElement(By.XPath("//tr[6]//td[7]"));
            action.DoubleClick(timetable).Perform();
            Thread.Sleep(600);
            //(2)write the title
            GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class,'k-edit-field')]//input[contains(@name,'title')]")).Clear();
            GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class,'k-edit-field')]//input[contains(@name,'title')]")).SendKeys("Thai Boxing");
            //(3) change the date（bug）

            // EndDateDropDown.Click();
            //  EndDateDropDown.Clear();
            //  EndDateDropDown.SendKeys("6/15/2013 13:30 PM");
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//textarea[@title='Description']")).SendKeys("GOOD SKILL");
            Thread.Sleep(500);
            //(4)save
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//a[@class='k-button k-primary k-scheduler-update']")).Click();
            //Exchange skills
            SkillExchange.SendKeys(ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchange.SendKeys(Keys.Enter);

            //upload the file//i[@class='huge plus circle icon padding-25']
            /*Thread.Sleep(2000);
            GlobalDefinitions.driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']")).Click();
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(1000);
            autoIt.Send(@"C:\Users\PIPER\Desktop\Skillwap_Test2-master\upload_File.txt");
            Thread.Sleep(1000);
            autoIt.Send("{ENTER}");*/


            // GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, "Xpath", " //input[@value='Save']", 5);
            Thread.Sleep(2800);
            //save
            Save.Click();
            Thread.Sleep(1500);
        }

        internal void EditShareSkill()
        {
            Thread.Sleep(1800);
            //click manage listings button
            GlobalDefinitions.driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']")).Click();
            Thread.Sleep(1800);
            // GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, "XPath", "//tr[1]//td[8]//div[1]//button[2]//i[1]", 5000);
            GlobalDefinitions.driver.FindElement(By.XPath("//tr[1]//td[8]//div[1]//button[2]//i[1]")).Click();
            //find the title
            //GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, "name", "title", 5000);
            Thread.Sleep(1800);

            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@name,'title')]")).Clear();
            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@name,'title')]")).SendKeys("Arts");
            //save
            Thread.Sleep(3000);
            GlobalDefinitions.driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            //GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, "XPath", , 5000);
            //Save.Click();

        }


        internal void DeleteShareSkill()
        {

            Thread.Sleep(1800);
            //click manage listings button
            GlobalDefinitions.driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']")).Click();
            Thread.Sleep(1800);
            //delete 
            GlobalDefinitions.driver.FindElement(By.XPath("//tr[1]//td[8]//div[1]//button[3]//i[1]")).Click();
            GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class,'tiny modal')]//button[contains(text(),'Yes')]")).Click();
        }




    }
}
