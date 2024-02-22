using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Pages.Components.signIn
{
    public  class LoginPageComponent : Base
    {
#pragma warning disable
        private IWebElement signInButton;
        private IWebElement emailTextbox;
        private IWebElement passwordTextbox;
        private IWebElement loginButton;
        private IWebElement passwordAlertMessage;
        private IWebElement emailAlertMessage;

        public void renderLoginInputComponents()
        {
            emailTextbox = driver.FindElement(By.Name("email"));
            passwordTextbox = driver.FindElement(By.Name("password"));
            loginButton = driver.FindElement(By.XPath("//*[text()='Login']"));
        }


        public void renderSignInComponent()
        {
            signInButton = driver.FindElement(By.CssSelector("a[class='item']"));

        }
        public void LoginDetails()
        {
            // Read login credentials from the JSON file
            string jsonFilePath = "C:\\ICProject\\AdvancedSpecFlow\\MarsAdvancedSpecflow\\SpecflowAutomation\\JsonData\\LoginTestData.json";
            // Deserialize the JSON content into LoginCredentials object
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Parse JSON using JObject
            JObject jsonObject = JObject.Parse(jsonContent);
#pragma warning disable CS8602

            string email = jsonObject["email"].ToString();
            string password = jsonObject["password"].ToString();
            renderSignInComponent();
            signInButton.Click();
            renderLoginInputComponents();
            // Enter the provided email
            emailTextbox.SendKeys(email);

            // Enter the provided password
            passwordTextbox.SendKeys(password);

            // Click the "Login" button
            Wait.WaitToBeClickable(driver, "XPath", "//*[text()='Login']", 5);
            loginButton.Click();

        }



    }
}
