using AventStack.ExtentReports;
using SpecflowAutomation.AssertHelper;
using SpecflowAutomation.Pages;
using SpecflowAutomation.Process;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Net.Http.Json;
using TechTalk.SpecFlow;

namespace SpecflowAutomation.StepDefinitions
{
    [Binding]
    public class LoginFeatureStepDefinitions : Base
    {
        private LocalPage localPageObj = new LocalPage();
        private LoginProcess loginProcessObj = new LoginProcess();
        private LoginAssert loginAssertObj = new LoginAssert();
#pragma warning disable
        private ExtentTest testreport;

        [Given(@"User is on the login page")]
        public void GivenUserIsOnTheLoginPage()
        {
            localPageObj.clickSingIn();
        }
        [When(@"Enter valid email and valid Password credentials from the Json file located at ""([^""]*)""")]
        public void WhenEnterValidEmailAndValidPasswordCredentialsFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<LoginTestModel> LoginData = Jsonhelper.ReadTestDataFromJson<LoginTestModel>(jsonContent);
            foreach (var data in LoginData)
            {
                LogScreenshot("ValidLogin");
                loginProcessObj.doLogin(data);
            }
        }
       [Then(@"User should be logged in successfully\.")]
        public void ThenUserShouldBeLoggedInSuccessfully_()
        {
            loginAssertObj.LoginAssertion();
           
        }
        [When(@"Enter valid email and Invalid Password credentials from the Json file located at ""([^""]*)""")]
        public void WhenEnterValidEmailAndInvalidPasswordCredentialsFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<LoginTestModel> LoginInvalidPassData = Jsonhelper.ReadTestDataFromJson<LoginTestModel>(jsonContent);
            foreach (var data in LoginInvalidPassData)
            {
                LogScreenshot("InvalidPass");
                loginProcessObj.InvalidPassProcess(data);
            }
        }
        [Then(@"User should be successfully got the error message\.")]
        public void ThenUserShouldBeSuccessfullyGotTheErrorMessage_()
        {
            loginAssertObj.InvalidPasswordAssert();
        }
        [When(@"Enter Invalid email and valid Password credentials from the Json file located at ""([^""]*)""")]
        public void WhenEnterInvalidEmailAndValidPasswordCredentialsFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<LoginTestModel> LoginInvalidUserData = Jsonhelper.ReadTestDataFromJson<LoginTestModel>(jsonContent);
            foreach (var data in LoginInvalidUserData)
            {
                LogScreenshot("invalidUsername");
                loginProcessObj.invalidUsernameProcess(data);
            }
        }
        [Then(@"User should be successfully saw the error message\.")]
        public void ThenUserShouldBeSuccessfullySawTheErrorMessage_()
        {
             loginAssertObj.InvalidUsernameAssert();
        }


    }
}
