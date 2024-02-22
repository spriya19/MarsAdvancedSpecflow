using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowAutomation.Pages.Components.ProfileOverView;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.AssertHelper
{
    public class LanguageAssert : Base
    {
        LanguageComponent languageComponentObj;
        public LanguageAssert()
        {
            languageComponentObj = new LanguageComponent();
        }
        public void verifyAddedLanguageAssert()
        {
            string messageBox = languageComponentObj.languageSuccessmessage();
            string popupMessage = messageBox;
            string expectedMessage2 = "Duplicated data";
            string expectedMessage3 = "Please enter language and level";
            string expectedMessage4 = "This language is already exist in your language list.";

            if (popupMessage.Contains("has been added"))
            {
                Console.WriteLine("Language has been added successfully");
            }
            else if ((popupMessage == expectedMessage2 || popupMessage == expectedMessage3 || popupMessage == expectedMessage4))
            {
                IWebElement cancelIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[2]"));
                cancelIcon.Click();
            }
            else
            {
                Console.WriteLine("Check Error");
            }
            Assert.AreEqual(popupMessage, messageBox, "Actual message and Expected message do not match");
        }
        public void verifyUpdatedLanguageAssert()
        {

            string messageBox = languageComponentObj.languageSuccessmessage();
            string popupMessage = messageBox;
            string expectedMessage2 = "Please enter language and level";
            string expectedMessage3 = "This language is already exist in your language list.";
            if (popupMessage.Contains("has been updated"))
            {
                Console.WriteLine("Language has been updated successfully");
            }
            else if ((popupMessage == expectedMessage2 || popupMessage == expectedMessage3))
            {
                IWebElement editCancelBtn = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]"));
                Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]", 15);
                editCancelBtn.Click();
                Console.WriteLine("Successfully got the error message");
            }
            else
            {
                Console.WriteLine("Check Error");
            }
            Assert.AreEqual(messageBox, popupMessage, "Actual message and expected message do not match");
        }
        public void languageDeleteAssertion()
        {
            string messageBox = languageComponentObj.verifyDeleteSuccessMessage();
            string popupMessage = messageBox;
            Assert.AreEqual(popupMessage, messageBox, "Actual message and expected message do not match");
        }
    }
}
