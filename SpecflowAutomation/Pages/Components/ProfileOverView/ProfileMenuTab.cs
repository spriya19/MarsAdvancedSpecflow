using OpenQA.Selenium;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Pages.Components.ProfileOverView
{
    public class ProfileMenuTab : Base
    {
#pragma warning disable
        private IWebElement userNameDropdownIcon;
        private IWebElement availabilityEditBtn;
        private IWebElement hoursEditBtn;
        private IWebElement earnTargetEditBtn;
        private IWebElement descriptionEditBtn;
        private IWebElement languageTab;
        private IWebElement editIcon;
        private IWebElement deleteIcon;
        private IWebElement shareSkillTab;
        private IWebElement sharemanageListingTab;
        private IWebElement manageListing;
        private IWebElement editManageListing;
        public void renderComponents()
        {
            try
            {
                userNameDropdownIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]//section[2]//div[2]//div[2]//div[1]/i"));
                availabilityEditBtn = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]//section[2]//div[2]//div[3]//div[2]/div/span/i"));
                hoursEditBtn = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]//section[2]//div[2]//div/div/div[3]//div[3]/div/span/i"));
                earnTargetEditBtn = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]//section[2]//div[2]//div[3]//div[4]/div/span/i"));
                descriptionEditBtn = driver.FindElement(By.XPath("(//i[@class='outline write icon'])[1]"));
                languageTab = driver.FindElement(By.XPath("//a[normalize-space()='Languages']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderEditComponent()
        {
            editIcon = driver.FindElement(By.XPath("//td[@class='right aligned']//i[@class='outline write icon']"));

        }
        public void renderDeleteComponent()
        {
            deleteIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
        }
        public void rendershareskillComponent()
        {
            shareSkillTab = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/section[1]/div/div[2]/a"));
        }
        public void renderShareManageListingComponent()
        {
            sharemanageListingTab = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/section[1]/div/a[3]"));
        }
        public void renderManageListingComponent()
        {
            manageListing = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
        }
        public void renderEditShareSkilComponent()
        {
            editManageListing = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i"));
        }
        public void clickUserNameIcon()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]//section[2]//div[2]//div[2]//div[1]/i", 12);
            renderComponents();
            userNameDropdownIcon.Click();
            Thread.Sleep(2000);
        }
        public void clickAvailabilityEditBtn()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]//section[2]//div[2]//div[3]//div[2]/div/span/i", 8);
            renderComponents();
            availabilityEditBtn.Click();
            Thread.Sleep(2000);
        }
        public void clickHoursEditBtn()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]//section[2]//div[2]//div/div/div[3]//div[3]/div/span/i", 10);
            renderComponents();
            hoursEditBtn.Click();
        }
        public void clickEarnTargetEditBtn()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]//section[2]//div[2]//div[3]//div[4]/div/span/i", 12);
            renderComponents();
            earnTargetEditBtn.Click();
        }
        public void clickDescripitionEditBtn()
        {
            Thread.Sleep(2500);
            Wait.WaitToBeClickable(driver, "XPath", "(//i[@class='outline write icon'])[1]", 12);
            renderComponents();
            descriptionEditBtn.Click();
        }
        public void clickLanguageTab()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[normalize-space()='Languages']", 12);
            renderComponents();
            languageTab.Click();
        }
        public void clickLanguageEditIcon()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//td[@class='right aligned']//i[@class='outline write icon']", 12);
            renderEditComponent();
            editIcon.Click();
        }
        public void clickOnDeleteIcon()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i", 12);
            renderDeleteComponent();
            deleteIcon.Click();
        }
        public void clickOnShareSkillTab()
        {
            Thread.Sleep(2000);
            rendershareskillComponent();
            shareSkillTab.Click();
        }
        public void clickManagelisting()
        {
            renderShareManageListingComponent();
            sharemanageListingTab.Click();
        }
        public void clickProfileManageListing()
        {
            Thread.Sleep(2000);

            renderManageListingComponent();
            manageListing.Click();
            Wait.WaitToBeVisible(driver, "XPath", ".//i[@class='remove icon']", 20);

        }
        public void clickEditManageListing()
        {
            renderEditShareSkilComponent();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            editManageListing.Click();
        }
    }
}
