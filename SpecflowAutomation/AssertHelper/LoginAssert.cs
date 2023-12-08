using AventStack.ExtentReports;
using NUnit.Framework;
using SpecflowAutomation.Pages;
using SpecflowAutomation.Pages.Components.signIn;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.AssertHelper
{
    public class LoginAssert  :Base
    {
        HomePage homePageObj;   
        LoginComponent loginComponentObj;
#pragma warning disable 
        public LoginAssert()
        {
            homePageObj = new HomePage();
            loginComponentObj = new LoginComponent();
        }
        public void LoginAssertion()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "C:\\ICProject\\AdvancedSpecFlow\\MarsAdvancedSpecflow\\SpecflowAutomation\\JsonData\\LoginData.json";
            List<LoginTestModel> LoginData = Jsonhelper.ReadTestDataFromJson<LoginTestModel>(sFile);
            foreach (var data in LoginData)
            {
                string userNameLabel = homePageObj.VerifyUserName();
                string expectedUserName = "Hi " + data.firstname;
                Assert.AreEqual(userNameLabel, expectedUserName, "Actual and expected do not match");
               
            }
        }
        public void InvalidPasswordAssert()
        {
            string passwordAlertMessage = loginComponentObj.verifypassAlertMessage();
            string alertMessage = passwordAlertMessage;
            if (passwordAlertMessage.Contains("Password must be at least 6 characters"))
            {
                Console.WriteLine("Password must be at least 6 characters");
            }
            else
            {
                Console.WriteLine("Check Error");
            }

            Assert.AreEqual(alertMessage, passwordAlertMessage, "actual message and expected message do not match");
           
        }
        public void InvalidUsernameAssert()
        {
            string userNameAlertMessageBox = loginComponentObj.verifyUsernameMessage();
            string alertMessage = userNameAlertMessageBox;
            if (userNameAlertMessageBox.Contains("Please enter a valid email address"))
            {
                Console.WriteLine("Please enter a valid email address");
            }
            else
            {
                Console.WriteLine("Check Error");
            }
            Assert.AreEqual(alertMessage, userNameAlertMessageBox, "actual message and expected message do not match");
           
        }
    }
}
