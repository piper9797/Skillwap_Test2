
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;

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
            Thread.Sleep(5000);
            // click the share skill btn
            ShareSkillButton.Click();
            Thread.Sleep(2000);
            // fill in details
            //skill
            Title.SendKeys("Thai boxing");
            Description.SendKeys("Thai boxing exchanges Arts");
            //category
            CategoryDropDown.Click();
            SelectElement category = new SelectElement(CategoryDropDown);
            category.SelectByValue("8");
            Thread.Sleep(100);
            SelectElement category2= new SelectElement(SubCategoryDropDown);
            category2.SelectByValue("4");
            //tags
            Tags.SendKeys("fighting skill");
            Tags.SendKeys(Keys.Enter);
            //service type
            Global.GlobalDefinitions.driver.FindElement(By.XPath("(//input[contains(@name,'serviceType')])[2]")).Click();
            //skip location type
            //click week
            Thread.Sleep(1000);
            Global.GlobalDefinitions.driver.FindElement(By.LinkText("Week")).Click();
            //choose the time table
            // (1)double click 
            Actions action = new Actions(Global.GlobalDefinitions.driver);
            Thread.Sleep(600);
            IWebElement timetable =Global.GlobalDefinitions.driver.FindElement(By.XPath("//tr[6]//td[7]"));
            action.DoubleClick(timetable).Perform();
            Thread.Sleep(200);
            //(2)write the title
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class,'k-edit-field')]//input[contains(@name,'title')]")).Clear();
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class,'k-edit-field')]//input[contains(@name,'title')]")).SendKeys("Thai Boxing");
            //(3) change the date（bug）

           // EndDateDropDown.Click();
          //  EndDateDropDown.Clear();
          //  EndDateDropDown.SendKeys("6/15/2013 13:30 PM");
          Global.GlobalDefinitions.driver.FindElement(By.XPath("//textarea[@title='Description']")).SendKeys("GOOD SKILL");
                       
            //(4)save
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//a[@class='k-button k-primary k-scheduler-update']")).Click();
            //Exchange skills
            SkillExchange.SendKeys("Arts");
            SkillExchange.SendKeys(Keys.Enter);

            Thread.Sleep(500);
            //save
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            
            Thread.Sleep(500);

        }

        internal void EditShareSkill()
        {

        }
    }
}
