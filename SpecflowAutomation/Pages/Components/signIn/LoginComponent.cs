using OpenQA.Selenium;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Pages.Components.signIn
{
    public class LoginComponent :Base
    {
#pragma warning disable
        private IWebElement emailTextbox;
        private IWebElement passwordTextbox;
        private IWebElement loginButton;
        private IWebElement passwordAlertMessage;
        private IWebElement emailAlertMessage;

        public void renderComponents()
        {
            emailTextbox = driver.FindElement(By.Name("email"));
            passwordTextbox = driver.FindElement(By.Name("password"));
            loginButton = driver.FindElement(By.XPath("//*[text()='Login']"));
        }
        public void renderPassAlertComponent()
        {
            passwordAlertMessage = driver.FindElement(By.XPath("//div[contains(text(),'Password must be at least 6 characters')]"));
        }
        public void renderUsernameMessageComponent()
        {
            emailAlertMessage = driver.FindElement(By.XPath("//div[contains(text(),'Please enter a valid email address')]"));
        }

        public void validLogin(LoginTestModel data)
        {
            renderComponents();
            emailTextbox.SendKeys(data.email);
            passwordTextbox.SendKeys(data.password);
            loginButton.Click();

        }
        public void validUserInvalidPassword(LoginTestModel data)
        {
            renderComponents();
            emailTextbox.SendKeys(data.email);
            passwordTextbox.SendKeys(data.password);
            loginButton.Click();
        }
        public string verifypassAlertMessage()
        {
            renderPassAlertComponent();
            return passwordAlertMessage.Text;
        }
        public void invalidUsernameValidPassword(LoginTestModel data)
        {
            renderComponents();
            emailTextbox.SendKeys(data.email);
            passwordTextbox.SendKeys(data.password);
            loginButton.Click();
        }
        public string verifyUsernameMessage()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[contains(text(),'Please enter a valid email address')]", 12);
            renderUsernameMessageComponent();
            return emailAlertMessage.Text;
        }

    }
}
