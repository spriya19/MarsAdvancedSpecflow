using OpenQA.Selenium;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Pages
{
    public class HomePage : Base
    {
#pragma warning disable
        private IWebElement userNameLabel;

        public void renderUserComponent()
        {
            userNameLabel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));
        }
        public string VerifyUserName()
        {
            Thread.Sleep(2000);
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span", 12);
            renderUserComponent();
            return userNameLabel.Text;
        }

    }
}
