using OpenQA.Selenium;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Pages
{
    public class LocalPage : Base
    {
#pragma warning disable
        private IWebElement signInButton;

        public void renderComponents()
        {
            signInButton = driver.FindElement(By.CssSelector("a[class='item']"));
        }

        public void clickSingIn()
        {
            renderComponents();
            Wait.WaitToBeClickable(driver, "CssSelector", "a[class='item']", 15);

            signInButton.Click();
        }
    }
}
