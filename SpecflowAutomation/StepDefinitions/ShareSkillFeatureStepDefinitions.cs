using SpecflowAutomation.AssertHelper;
using SpecflowAutomation.Pages.Components.ProfileOverView;
using SpecflowAutomation.Pages.Components.ServiceListingOverView;
using SpecflowAutomation.Pages.Components.signIn;
using SpecflowAutomation.Process;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecflowAutomation.StepDefinitions
{
    [Binding]
    public class ShareSkillFeatureStepDefinitions : Base
    {
        private LoginPageComponent loginPageComponentObj = new LoginPageComponent();
        private LoginAssert loginAssertObj = new LoginAssert();
        private ProfileMenuTab profileMenuTabObj = new ProfileMenuTab();
        private ShareSkillProcess shareSkillProcessObj = new ShareSkillProcess();
        private ShareSkillAssert shareSkillAssertObj = new ShareSkillAssert();

        [Given(@"User Successfully Logged in with valid details\.")]
        public void GivenUserSuccessfullyLoggedInWithValidDetails_()
        {
            loginPageComponentObj.LoginDetails();
            loginAssertObj.LoginAssertion();
        }

        [When(@"User add share skill  using Json File with located at ""([^""]*)""")]
        public void WhenUserAddShareSkillUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            // Read test data from the JSON file using JsonHelper
            string jsonContent = jsonFilePath;
            List<ShareSkillTestModel> ShareSkillAddData = Jsonhelper.ReadTestDataFromJson<ShareSkillTestModel>(jsonContent);
            foreach (var data in ShareSkillAddData)
            {
                LogScreenshot("Add ShareSkill");
                shareSkillProcessObj.addShareSkillDetails(data);
            }
        }

        [Then(@"User Should be successfully added the ShareSkill\.")]
        public void ThenUserShouldBeSuccessfullyAddedTheShareSkill_()
        {
            profileMenuTabObj.clickManagelisting();
            shareSkillAssertObj.addShareSkillAssert();
        }
        [When(@"User update the share skill  using Json File with located at ""([^""]*)""")]
        public void WhenUserUpdateTheShareSkillUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            // Read test data from the JSON file using JsonHelper
            string jsonContent = jsonFilePath;
            List<ShareSkillTestModel> ShareskillUpdateData = Jsonhelper.ReadTestDataFromJson<ShareSkillTestModel>(jsonContent);
            foreach (var data in ShareskillUpdateData)
            {
                LogScreenshot("Updated ShareSkill");
                shareSkillProcessObj.shareSkillUpdate(data);
            }
        }
        [Then(@"User Should be successfully updated the ShareSkill\.")]
        public void ThenUserShouldBeSuccessfullyUpdatedTheShareSkill_()
        {
            shareSkillAssertObj.shareSkillUpdateAssert();
        }
        [When(@"User delete the share skill  using Json File with located at ""([^""]*)""")]
        public void WhenUserDeleteTheShareSkillUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<ShareSkillTestModel> ShareSkillDelete = Jsonhelper.ReadTestDataFromJson<ShareSkillTestModel>(jsonContent);
            foreach (var data in ShareSkillDelete)
            {
                string title = data.title;
                LogScreenshot("Deleted ShareSkill");
                shareSkillProcessObj.shareSkillDeleteProcess(title);
            }
        }
        [Then(@"User Should be successfully Deleted the ShareSkill\.")]
        public void ThenUserShouldBeSuccessfullyDeletedTheShareSkill_()
        {
            shareSkillAssertObj.DeleteShareSkillAssert();
        }
        [When(@"User add negative share skill  using Json File with located at ""([^""]*)""")]
        public void WhenUserAddNegativeShareSkillUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            // Read test data from the JSON file using JsonHelper
            string jsonContent = jsonFilePath;
            List<ShareSkillTestModel> ShareSkillAddNegativeData = Jsonhelper.ReadTestDataFromJson<ShareSkillTestModel>(jsonContent);
            foreach (var data in ShareSkillAddNegativeData)
            {
                LogScreenshot("Add Negative ShareSkill");
                shareSkillProcessObj.negativeAddShareSkillProcess(data);
            }
        }
        [Then(@"User Should be successfully got the error message while added negative the ShareSkill\.")]
        public void ThenUserShouldBeSuccessfullyGotTheErrorMessageWhileAddedNegativeTheShareSkill_()
        {
            shareSkillAssertObj.negativeAddShareSkillAssert();
        }
        [When(@"User update negative share skill  using Json File with located at ""([^""]*)""")]
        public void WhenUserUpdateNegativeShareSkillUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            // Read test data from the JSON file using JsonHelper
            string jsonContent = jsonFilePath;
            List<ShareSkillTestModel> ShareSkillUpdateNegativeData = Jsonhelper.ReadTestDataFromJson<ShareSkillTestModel>(jsonContent);
            foreach (var data in ShareSkillUpdateNegativeData)
            {
                LogScreenshot("Updated Negative ShareSkill");
                shareSkillProcessObj.negativeShareskillUpdateProcess(data);
            }
        }
        [Then(@"User Should be successfully got the error message while Updated negative ShareSkill\.")]
        public void ThenUserShouldBeSuccessfullyGotTheErrorMessageWhileUpdatedNegativeShareSkill_()
        {
            shareSkillAssertObj.negativeShareskillUpdateAssert();
        }






    }
}
