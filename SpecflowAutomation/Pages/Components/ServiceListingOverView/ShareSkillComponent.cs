using OpenQA.Selenium;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Pages.Components.ServiceListingOverView
{
    public class ShareSkillComponent : Base
    {
#pragma warning disable
        private IWebElement addTitle;
        private IWebElement addDescription;
        private IWebElement chooseCategory;
        private IWebElement chooseSubcategory;
        private IWebElement addTag;
        private IWebElement servicetypeRadioBtn;
        private IWebElement locationtypeRadioBtn;
        private IWebElement selectStartDate;
        private IWebElement selectEndDate;
        private IWebElement SkillExchangeRadiobutton;
        private IWebElement skillExchangeTag;
        private IWebElement creditValue;
        private IWebElement activeRadioBtn;
        private IWebElement saveButton;
        private IWebElement selectStartTime;
        private IWebElement selectEndTime;
        private IWebElement availableSunday;
        private IWebElement addedSkillcategory;
        private IWebElement updatedSkill;
        private IWebElement errorMessageBox;
        private IWebElement cancelBtn;
        private IWebElement yesBtn;
        public void renderShareSkillInputComponents()
        {
            try
            {
                addTitle = driver.FindElement(By.Name("title"));
                addDescription = driver.FindElement(By.Name("description"));
                chooseCategory = driver.FindElement(By.Name("categoryId"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSubcategoryComponent()
        {
            chooseSubcategory = driver.FindElement(By.Name("subcategoryId"));
        }
        public void renderTagComponent()
        {
            addTag = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        }
        public void renderTypeComponents()
        {
            servicetypeRadioBtn = driver.FindElement(By.XPath("//input[@name='serviceType' and @value='1']"));
            locationtypeRadioBtn = driver.FindElement(By.Name("locationType"));
        }
        public void renderDaysComponents()
        {
            selectStartDate = driver.FindElement(By.Name("startDate"));
            selectEndDate = driver.FindElement(By.Name("endDate"));

        }
        public void renderTimeComponents()
        {
            //availableSunday = driver.FindElement(By.Name("Available"));
            availableSunday = driver.FindElement(By.XPath("//input[@name='Available' and @index='0']"));
            selectStartTime = driver.FindElement(By.Name("StartTime"));
            selectEndTime = driver.FindElement(By.Name("EndTime"));
        }
        public void renderTradeComponents()
        {
            SkillExchangeRadiobutton = driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='true']"));
            skillExchangeTag = driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"));
            //creditValue = driver.FindElement(By.Name("charge"));
        }
        public void renderactiveComponent()
        {
            activeRadioBtn = driver.FindElement(By.Name("isActive"));
            //activeRadioBtn = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));
        }
        public void rendersaveComponent()
        {
            saveButton = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
        }
        public void renderAddedSkillTestComponent()
        {
            addedSkillcategory = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]"));
        }
        public void renderEditedShareSkillComponent()
        {
            updatedSkill = driver.FindElement(By.XPath("//td[normalize-space()='Music & Audio']"));
        }
        public void renderErrorMessageComponent()
        {
            errorMessageBox = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));

        }
        public void renderCancelcomponent()
        {
            cancelBtn = driver.FindElement(By.XPath("//input[@value='Cancel']"));
        }
        public void renderAlertWindowComponent()
        {
            yesBtn = driver.FindElement(By.XPath("//button[normalize-space()='Yes']"));
        }

        public void shareSkillDes(ShareSkillTestModel skilladd)
        {
            Thread.Sleep(2000);
            renderShareSkillInputComponents();
            //enter the Title
            addTitle.SendKeys(skilladd.title);
            //Enter the Description
            addDescription.SendKeys(skilladd.description);
            chooseCategory.SendKeys(skilladd.category);
            renderSubcategoryComponent();
            chooseSubcategory.SendKeys(Keys.Tab);
            chooseSubcategory.SendKeys(skilladd.subcategory);
        }
        public void shareSkillTag(ShareSkillTestModel skilladd)
        {
            renderTagComponent();
            addTag.SendKeys(skilladd.tags);
            addTag.SendKeys(Keys.Enter);
        }
        public void shareskillType()
        {
            Thread.Sleep(1000);
            renderTypeComponents();
            servicetypeRadioBtn.Click();
            locationtypeRadioBtn.Click();
        }
        public void shareSkillDays(ShareSkillTestModel skilladd)
        {
            renderDaysComponents();
            selectStartDate.SendKeys(skilladd.startdate);
            selectEndDate.SendKeys(skilladd.enddate);
            renderTimeComponents();
            selectStartTime.SendKeys(skilladd.starttime);
            selectEndTime.SendKeys(skilladd.endtime);
        }

        public void shareSkillTrade(ShareSkillTestModel skilladd)
        {
            Thread.Sleep(2000);
            renderTradeComponents();
            SkillExchangeRadiobutton.Click();
            skillExchangeTag.SendKeys(skilladd.skillExchange);
            skillExchangeTag.SendKeys(Keys.Enter);
        }
        public void shareskillActive()
        {
            Thread.Sleep(3000);
            renderactiveComponent();
            activeRadioBtn.Click();
            rendersaveComponent();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]", 12);
            saveButton.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            saveButton.Submit();

        }
        public void clearExistingShareskillData()
        {
            try
            {
                // Find all delete buttons
                var deleteButtons = driver.FindElements(By.XPath(".//i[@class='remove icon']"));

                // Ensure there's at least one item
                if (deleteButtons.Count > 2) // Change to > 1 if you want to keep one item
                {
                    // Iterate through delete buttons starting from the second one
                    for(int i = 2; i < deleteButtons.Count; i++)
                    {
                        // Click the delete button
                        deleteButtons[i].Click();

                        // Wait for the confirmation dialog
                        Wait.WaitToBeClickable(driver, "XPath", "//button[normalize-space()='Yes']", 12);

                        // Handle the confirmation and delete
                        renderAlertWindowComponent();
                        var yesBtn = driver.FindElement(By.XPath("//button[normalize-space()='Yes']"));
                        Thread.Sleep(2000);
                        yesBtn.Click();
                    }
                }
                else
                {
                    Console.WriteLine("Keeping at least one item. No additional items to delete.");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No items to delete.");
            }

        }

        public void shareSkillAdd(ShareSkillTestModel skilladd)
        {

            shareSkillDes(skilladd);
            shareSkillTag(skilladd);
            shareskillType();
            shareSkillDays(skilladd);
            shareSkillTrade(skilladd);
            shareskillActive();

        }
        public string verifSkillCategory()
        {
            Thread.Sleep(3000);
            renderAddedSkillTestComponent();
            return addedSkillcategory.Text;
        }
        public void EditShareSkill(ShareSkillTestModel skilladd)
        {
            renderShareSkillInputComponents();
            //enter the Title
            addTitle.SendKeys(Keys.Control + "A");
            addTitle.SendKeys(Keys.Delete);
            addTitle.SendKeys(skilladd.title);
            //Enter the Description
            addDescription.SendKeys(Keys.Control + "A");
            addDescription.SendKeys(Keys.Delete);
            addDescription.SendKeys(skilladd.description);
            chooseCategory.SendKeys(skilladd.category);
            renderSubcategoryComponent();
            chooseSubcategory.SendKeys(Keys.Tab);
            chooseSubcategory.SendKeys(skilladd.subcategory);
            renderTagComponent();
            addTag.SendKeys(skilladd.tags);
            addTag.SendKeys(Keys.Enter);
            renderTypeComponents();
            servicetypeRadioBtn.Click();
            locationtypeRadioBtn.Click();
            renderDaysComponents();
            selectStartDate.SendKeys(skilladd.startdate);
            selectEndDate.SendKeys(skilladd.enddate);
            renderTimeComponents();
            selectStartTime.SendKeys(skilladd.starttime);
            selectEndTime.SendKeys(skilladd.endtime);
            renderTradeComponents();
            SkillExchangeRadiobutton.Click();
            skillExchangeTag.SendKeys(skilladd.skillExchange);
            skillExchangeTag.SendKeys(Keys.Enter);
            renderactiveComponent();
            activeRadioBtn.Click();
            rendersaveComponent();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]", 12);
            saveButton.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            saveButton.Submit();
        }
        public string verifyUpdatedShareSkill()
        {
            Thread.Sleep(3000);
            renderEditedShareSkillComponent();
            return updatedSkill.Text;
        }
        public void negativeShareSkill(ShareSkillTestModel skilladd)
        {
            renderShareSkillInputComponents();
            //enter the Title
            addTitle.SendKeys(Keys.Control + "A");
            addTitle.SendKeys(Keys.Delete);
            addTitle.SendKeys(skilladd.title);
            //Enter the Description
            addDescription.SendKeys(Keys.Control + "A");
            addDescription.SendKeys(Keys.Delete);
            addDescription.SendKeys(skilladd.description);
            chooseCategory.SendKeys(skilladd.category);
            renderSubcategoryComponent();
            chooseSubcategory.SendKeys(Keys.Tab);
            chooseSubcategory.SendKeys(skilladd.subcategory);
            renderTagComponent();
            addTag.SendKeys(skilladd.tags);
            addTag.SendKeys(Keys.Enter);
            renderTypeComponents();
            servicetypeRadioBtn.Click();
            locationtypeRadioBtn.Click();
            renderDaysComponents();
            selectStartDate.SendKeys(skilladd.startdate);
            selectEndDate.SendKeys(skilladd.enddate);
            renderTimeComponents();
            selectStartTime.SendKeys(skilladd.starttime);
            selectEndTime.SendKeys(skilladd.endtime);
            renderTradeComponents();
            SkillExchangeRadiobutton.Click();
            skillExchangeTag.SendKeys(skilladd.skillExchange);
            skillExchangeTag.SendKeys(Keys.Enter);
            renderactiveComponent();
            activeRadioBtn.Click();
            rendersaveComponent();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]", 12);
            saveButton.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            saveButton.Submit();
            renderCancelcomponent();
            cancelBtn.Submit();
        }
        public string verifyErrorMessage()
        {
            Thread.Sleep(2000);
            renderErrorMessageComponent();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(26);
            return errorMessageBox.Text;

        }
        public void negativeShareSkillUpdate(ShareSkillTestModel skilladd)
        {
            renderShareSkillInputComponents();
            //enter the Title
            addTitle.SendKeys(Keys.Control + "A");
            addTitle.SendKeys(Keys.Delete);
            addTitle.SendKeys(skilladd.title);
            //Enter the Description
            addDescription.SendKeys(Keys.Control + "A");
            addDescription.SendKeys(Keys.Delete);
            addDescription.SendKeys(skilladd.description);
            chooseCategory.SendKeys(skilladd.category);
            renderSubcategoryComponent();
            chooseSubcategory.SendKeys(Keys.Tab);
            chooseSubcategory.SendKeys(skilladd.subcategory);
            renderTagComponent();
            addTag.SendKeys(skilladd.tags);
            addTag.SendKeys(Keys.Enter);
            renderTypeComponents();
            servicetypeRadioBtn.Click();
            locationtypeRadioBtn.Click();
            renderDaysComponents();
            selectStartDate.SendKeys(skilladd.startdate);
            selectEndDate.SendKeys(skilladd.enddate);
            renderTimeComponents();
            selectStartTime.SendKeys(skilladd.starttime);
            selectEndTime.SendKeys(skilladd.endtime);
            renderTradeComponents();
            SkillExchangeRadiobutton.Click();
            skillExchangeTag.SendKeys(skilladd.skillExchange);
            skillExchangeTag.SendKeys(Keys.Enter);
            renderactiveComponent();
            activeRadioBtn.Click();
            rendersaveComponent();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]", 12);
            saveButton.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            saveButton.Submit();
            renderCancelcomponent();
            cancelBtn.Click();
        }
    }

}

