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
    public class LanguageFeatureStepDefinitions : Base
    {
        private LoginPageComponent loginPageComponentObj = new LoginPageComponent();
        private LoginAssert loginAssertObj = new LoginAssert();
        private LanguageProcess languageProcessObj = new LanguageProcess();
        private LanguageAssert  languageAssertObj = new LanguageAssert();
        [Given(@"User should be logged in with valid credentials\.")]
        public void GivenUserShouldBeLoggedInWithValidCredentials_()
        {
            loginPageComponentObj.LoginDetails();
            loginAssertObj.LoginAssertion();
        }

        [When(@"Enter user Language using Json File with located at ""([^""]*)""")]
        public void WhenEnterUserLanguageUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            languageProcessObj.ClearLanguageProcess();
            string jsonContent = jsonFilePath;
            List<LanguageTestModel> LanguageAddData = Jsonhelper.ReadTestDataFromJson<LanguageTestModel>(jsonContent);
            foreach(var data  in LanguageAddData)
            {
                LogScreenshot("Add Language");
                languageProcessObj.languageAddProcess(data);
            }
        }

        [Then(@"User Should be successfully added the language\.")]
        public void ThenUserShouldBeSuccessfullyAddedTheLanguage_()
        {
            languageAssertObj.verifyAddedLanguageAssert();
        }
        [When(@"User Updated Language using Json File with located at ""([^""]*)""")]
        public void WhenUserUpdatedLanguageUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<LanguageTestModel> LanguageUpdateData = Jsonhelper.ReadTestDataFromJson<LanguageTestModel>(jsonContent);
            foreach (var data in LanguageUpdateData)
            {
                LogScreenshot("Updated Language");
               languageProcessObj.languageUpdateProcess(data);
            }
        }
        [Then(@"User Should be successfully Updated the language\.")]
        public void ThenUserShouldBeSuccessfullyUpdatedTheLanguage_()
        {
            languageAssertObj.verifyUpdatedLanguageAssert();
        }
        [When(@"User Delete Language using Json File with located at ""([^""]*)""")]
        public void WhenUserDeleteLanguageUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<LanguageTestModel> LanguageDeleteData = Jsonhelper.ReadTestDataFromJson<LanguageTestModel>(jsonContent);
            foreach (var data in LanguageDeleteData)
            {
                string language = data.language;
                LogScreenshot("Deleted Language");
                languageProcessObj.languageDeleteProcess(language);
            }
        }
        [Then(@"User Should be successfully deleted the language\.")]
        public void ThenUserShouldBeSuccessfullyDeletedTheLanguage_()
        {
            languageAssertObj.languageDeleteAssertion();
        }
        [When(@"User add Negative Language using Json File with located at ""([^""]*)""")]
        public void WhenUserAddNegativeLanguageUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            languageProcessObj.ClearLanguageProcess();
            string jsonContent = jsonFilePath;
            List<LanguageTestModel> LanguageAddNegativeData = Jsonhelper.ReadTestDataFromJson<LanguageTestModel>(jsonContent);
            foreach (var data in LanguageAddNegativeData)
            {
                LogScreenshot("Add Negative Language");
                languageProcessObj.languageAddNegativeProcess(data);
            }
        }
        [Then(@"User Should be successfully got the Error message added negative language\.")]
        public void ThenUserShouldBeSuccessfullyGotTheErrorMessageAddedNegativeLanguage_()
        {
            languageAssertObj.verifyAddedLanguageAssert();
        }
        [When(@"User update Negative Language using Json File with located at ""([^""]*)""")]
        public void WhenUserUpdateNegativeLanguageUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<LanguageTestModel> LanguageUpdateNegativeData = Jsonhelper.ReadTestDataFromJson<LanguageTestModel>(jsonContent);
            foreach (var data in LanguageUpdateNegativeData)
            {
                LogScreenshot("Update Negative Language");
                languageProcessObj.languageUpdatedNegativeProcess(data);
            }
        }
        [Then(@"User Should be successfully got the Error message update negative language\.")]
        public void ThenUserShouldBeSuccessfullyGotTheErrorMessageUpdateNegativeLanguage_()
        {
            languageAssertObj.verifyUpdatedLanguageAssert();    
        }


    }
}
