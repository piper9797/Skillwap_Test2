using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test]
            
            public void Share_New_Skill_Test()
            {
              
                // share a new skill
                ShareSkill shareSkill = new ShareSkill();
                shareSkill.ShareNewSkill();
                //Assert
                Thread.Sleep(2000);
                var titleElement= Global.GlobalDefinitions.driver.FindElement(By.XPath("//tr[1]//td[3]")).Text;
                Assert.AreEqual("Thai boxing", titleElement);
            }

            
            [Test]
            public void Edit_And_Save_Invalid_Skill_Test()
            {

                // share a new skill
                ShareSkill shareSkill = new ShareSkill();
                shareSkill.EditShareSkill();
                //Assert
                Thread.Sleep(2000);
                //tr[1]//td[3]
                var titleElement = Global.GlobalDefinitions.driver.FindElement(By.XPath("//tr[1]//td[3]")).Text;
                Assert.AreEqual("Arts", titleElement);
            }

            [Test]
            public void Delete_Invalid_Skill_Test()
            {

                ShareSkill shareSkill = new ShareSkill();
                shareSkill.DeleteShareSkill();

            }

        }
    }
}