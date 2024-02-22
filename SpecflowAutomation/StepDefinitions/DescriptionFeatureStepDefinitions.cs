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
    public class DescriptionFeatureStepDefinitions :Base
    {
        private LoginPageComponent loginPageComponentObj = new LoginPageComponent();
        private LoginAssert loginAssertObj = new LoginAssert();
        private DescriptionProcess descriptionProcessObj = new DescriptionProcess();
        private DescriptionAssert descriptionAssertObj = new DescriptionAssert();

        [Given(@"User should be successfully logged with valid credential\.")]
        public void GivenUserShouldBeSuccessfullyLoggedWithValidCredential_()
        {
            loginPageComponentObj.LoginDetails();
            loginAssertObj.LoginAssertion();
        }

        [When(@"Enter user Description using Json File with located at ""([^""]*)""")]
        public void WhenEnterUserDescriptionUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<DescriptionTestModel> DescriptionData = Jsonhelper.ReadTestDataFromJson<DescriptionTestModel>(jsonContent);
            foreach (var data in DescriptionData)
            {
                LogScreenshot("AddDescription");
                descriptionProcessObj.AddedDescription(data);
            }
        }

        [Then(@"User Should be successfully Enter the Description\.")]
        public void ThenUserShouldBeSuccessfullyEnterTheDescription_()
        {
            descriptionAssertObj.verifyDescriptionAssert();
        }
        [When(@"User Updated Description using Json File with located at ""([^""]*)""")]
        public void WhenUserUpdatedDescriptionUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<DescriptionTestModel> DescriptionUpdateData = Jsonhelper.ReadTestDataFromJson<DescriptionTestModel>(jsonContent);
            foreach (var data in DescriptionUpdateData)
            {
                LogScreenshot("UpdateDescription");
                descriptionProcessObj.UpdatedDescription(data);
            }
        }
        [Then(@"User Should be successfully Updated the Description\.")]
        public void ThenUserShouldBeSuccessfullyUpdatedTheDescription_()
        {
            descriptionAssertObj.verifyDescriptionAssert();
        }
        [When(@"User delete Description using Json File with located at ""([^""]*)""")]
        public void WhenUserDeleteDescriptionUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<DescriptionTestModel> DescriptionDeleteData = Jsonhelper.ReadTestDataFromJson<DescriptionTestModel>(jsonContent);
            foreach (var data in DescriptionDeleteData)
            {
                LogScreenshot("DeleteDescription");
               descriptionProcessObj.deleteDescription(data);
            }
        }
        [Then(@"User Should be successfully Deleted the Description\.")]
        public void ThenUserShouldBeSuccessfullyDeletedTheDescription_()
        {
            descriptionAssertObj.verifyDescriptionAssert();
        }
        [When(@"User Enter Negative Description using Json File with located at ""([^""]*)""")]
        public void WhenUserEnterNegativeDescriptionUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<DescriptionTestModel> DescriptionNegativeData = Jsonhelper.ReadTestDataFromJson<DescriptionTestModel>(jsonContent);
            foreach (var data in DescriptionNegativeData)
            {
                LogScreenshot("NegativeDescription");
                descriptionProcessObj.NegativeDescri(data);
            }
        }
        [Then(@"User Should be successfully Enter the Negative Description\.")]
        public void ThenUserShouldBeSuccessfullyEnterTheNegativeDescription_()
        {
            descriptionAssertObj.verifyDescriptionAssert();
        }
    }
}
