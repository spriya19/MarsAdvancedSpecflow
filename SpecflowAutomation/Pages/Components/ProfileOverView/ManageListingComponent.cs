using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Pages.Components.ProfileOverView
{
    public class ManageListingComponent : Base
    {
#pragma warning disable
        private IWebElement deleteIcon;
        private IWebElement yesBtn;
        private IWebElement noBtn;
        private IWebElement messageBox;

        public void renderDeleteComponent()
        {
            deleteIcon = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));
        }
        public void renderAlertWindowComponent()
        {
            yesBtn = driver.FindElement(By.XPath("//button[normalize-space()='Yes']"));
            noBtn = driver.FindElement(By.XPath("//button[normalize-space()='No']"));
        }
        public void renderDelMessageWindowComponent()
        {
            messageBox = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
        }
        public void deleteManageList()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i", 12);
            renderDeleteComponent();
            deleteIcon.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//button[normalize-space()='Yes']", 12);
            renderAlertWindowComponent();
            yesBtn.Click();
        }
        public void deleteShareSkill(string title)
        {
            string deleteIconXPath = $"//tbody[tr[td[text()='{title}']]]//button[3]";
            IWebElement deleteIcon = driver.FindElement(By.XPath(deleteIconXPath));
            deleteIcon.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//button[normalize-space()='Yes']", 12);
            renderAlertWindowComponent();
            yesBtn.Click();


        }
        public string verifyDeletedList()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 12);
            renderDelMessageWindowComponent();
            return messageBox.Text;
        }

    }
}
