using OpenQA.Selenium;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Pages.Components.ProfileOverView
{
    public class LanguageComponent: Base
    {
#pragma warning disable
        private IWebElement addnewBtn;
        private IWebElement languageTab;
        private IWebElement languageTxtBox;
        private IWebElement levelTxtBox;
        private IWebElement addBtn;
        private IWebElement cancelBtn;
        private IWebElement languageEditTxtBox;
        private IWebElement levelEditTxtBox;
        private IWebElement updateBtn;
        private IWebElement messageBox;
        private IWebElement editCancelBtn;


        public void renderAddNewLanguageComponent()
        {
            addnewBtn = driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target']//div[contains(@class,'ui teal button')][normalize-space()='Add New']"));

        }

        public void renderLanguageInputComponents()
        {
            try
            {
                languageTab = driver.FindElement(By.XPath("//a[normalize-space()='Languages']"));
                languageTxtBox = driver.FindElement(By.Name("name"));
                levelTxtBox = driver.FindElement(By.Name("level"));
                addBtn = driver.FindElement(By.XPath("//input[@value='Add']"));
                cancelBtn = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderUpdateInputComponents()
        {
            languageEditTxtBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input"));
            levelEditTxtBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select"));

        }
        public void renderUpdateComponent()
        {
            updateBtn = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]"));
        }
        public void renderMessageComponent()
        {
            messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        }
        public void renderCancelButton()
        {
            editCancelBtn = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]"));
        }
        public void clearExistingdata()
        {
            try
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                var deleteButtons = driver.FindElements(By.XPath("//div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                foreach(var button in deleteButtons)
                {
                    button.Click();
                }

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("no items to delete");
            }

        }
        public void addNewLanguage(LanguageTestModel data)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui bottom attached tab segment active tooltip-target']//div[contains(@class,'ui teal button')][normalize-space()='Add New']", 12);
            renderAddNewLanguageComponent();
            addnewBtn.Click();
            renderLanguageInputComponents();
            languageTxtBox.SendKeys(data.language);
            levelTxtBox.SendKeys(data.level);
            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Add']", 12);
            addBtn.Click();
        }
        public void editLanguage(LanguageTestModel data)
        {
            renderUpdateInputComponents();
            languageEditTxtBox.Clear();
            languageEditTxtBox.SendKeys(data.language);
            Thread.Sleep(1000);
            levelEditTxtBox.SendKeys(data.level);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]", 12);
            renderUpdateComponent();
            updateBtn.Click();
        }
        public void deleteLanguageData(string language)
        {
            string deleteIconXPath = $"//tbody[tr[td[text()='{language}']]]//span[2]";
            IWebElement deleteIcon = driver.FindElement(By.XPath(deleteIconXPath));
            deleteIcon.Click();

        }

        public string verifyDeleteSuccessMessage()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 12);
            renderMessageComponent();
            return messageBox.Text;

        }
        public void addNegativeLanguage(LanguageTestModel data)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui bottom attached tab segment active tooltip-target']//div[contains(@class,'ui teal button')][normalize-space()='Add New']", 12);
            renderAddNewLanguageComponent();
            addnewBtn.Click();
            renderLanguageInputComponents();
            Thread.Sleep(1000);
            languageTxtBox.SendKeys(data.language);
            levelTxtBox.SendKeys(data.level);
            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Add']", 30);
            addBtn.Click();

        }
        public string languageSuccessmessage()
        {
            Thread.Sleep(2000);
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 12);
            renderMessageComponent();
            return messageBox.Text;

        }
        public void negtiveEditLanguage(LanguageTestModel data)
        {
            renderUpdateInputComponents();
            languageEditTxtBox.Clear();
            languageEditTxtBox.SendKeys(data.language);
            levelEditTxtBox.SendKeys(data.level);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]", 12);
            renderUpdateComponent();
            updateBtn.Click();
        }
    }
}

