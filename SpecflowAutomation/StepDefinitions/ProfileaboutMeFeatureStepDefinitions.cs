using SpecflowAutomation.AssertHelper;
using SpecflowAutomation.Pages.Components.signIn;
using SpecflowAutomation.Process;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecflowAutomation.StepDefinitions
{
    [Binding]
    public class ProfileaboutMeFeatureStepDefinitions : Base
    {
        private LoginPageComponent loginPageComponentObj = new LoginPageComponent();
        private LoginAssert loginAssertObj = new LoginAssert();
        private ProfileAboutMeProcess profileAboutMeProcessObj = new ProfileAboutMeProcess();
        private ProfileAboutMeAssert profileAboutMeAssertObj = new ProfileAboutMeAssert();

        [Given(@"User should be successfully logged with valid credentials\.")]
        public void GivenUserShouldBeSuccessfullyLoggedWithValidCredentials_()
        {
            loginPageComponentObj.LoginDetails();
            loginAssertObj.LoginAssertion();
        }

        [When(@"Enter user FirstName and Lastname using Json File with located at ""([^""]*)""")]
        public void WhenEnterUserFirstNameAndLastnameUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<ProfileAboutMeTestModel> ProfileUserData = Jsonhelper.ReadTestDataFromJson<ProfileAboutMeTestModel>(jsonContent);
            foreach (var data in ProfileUserData)
            {
                LogScreenshot("UserName");
                profileAboutMeProcessObj.updateUserName(data);
            }
        }

        [Then(@"User Should be successfully Enter the name\.")]
        public void ThenUserShouldBeSuccessfullyEnterTheName_()
        {
            profileAboutMeAssertObj.userVerifyAssertion();
        }
        [When(@"Enter user availability using Json file with located at ""([^""]*)""")]
        public void WhenEnterUserAvailabilityUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<ProfileAboutMeTestModel> ProfileAvailabilityData = Jsonhelper.ReadTestDataFromJson<ProfileAboutMeTestModel>(jsonContent);
            foreach (var data in ProfileAvailabilityData)
            {
                LogScreenshot("Availability Type");
                profileAboutMeProcessObj.updateAvailabilityType(data);
            }
        }
        [Then(@"User should be successfully Enter the Availability Type\.")]
        public void ThenUserShouldBeSuccessfullyEnterTheAvailabilityType_()
        {
            profileAboutMeAssertObj.userProfileAssert();
        }
        [When(@"Enter User Availability Hours using Json file with located at ""([^""]*)""")]
        public void WhenEnterUserAvailabilityHoursUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<ProfileAboutMeTestModel> profileHoursData = Jsonhelper.ReadTestDataFromJson<ProfileAboutMeTestModel>(jsonContent);
            foreach (var data in profileHoursData)
            {
                LogScreenshot("Availability Hours");
                profileAboutMeProcessObj.updateAvailabilityHours(data);
            }
        }
        [Then(@"User should be successfully Enter the Availability Hours Type\.")]
        public void ThenUserShouldBeSuccessfullyEnterTheAvailabilityHoursType_()
        {
            profileAboutMeAssertObj.userProfileAssert();
        }
        [When(@"Enter User Availability EarnTarget using Json file with located at ""([^""]*)""")]
        public void WhenEnterUserAvailabilityEarnTargetUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<ProfileAboutMeTestModel> profileEarnData = Jsonhelper.ReadTestDataFromJson<ProfileAboutMeTestModel>(jsonContent);
            foreach (var data in profileEarnData)
            {
                LogScreenshot("Availability EarnTarget");
                profileAboutMeProcessObj.updatedAvailabilityEarnTarget(data);

            }
        }
        [Then(@"User should be successfully Enter the Availability Earn Target Type\.")]
        public void ThenUserShouldBeSuccessfullyEnterTheAvailabilityEarnTargetType_()
        {
            profileAboutMeAssertObj.userProfileAssert();
        }






    }
}
