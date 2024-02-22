using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowAutomation.Pages.Components.ProfileOverView;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.AssertHelper
{
    public class ProfileAboutMeAssert : Base
    {

        ProfileAboutMe profileAboutMeObj;

        public ProfileAboutMeAssert()
        {
            profileAboutMeObj = new ProfileAboutMe();
        }
        public void userVerifyAssertion()
        {
            // Read test data from the JSON file using JsonHelper
            List<ProfileAboutMeTestModel> ProfileUserData = Jsonhelper.ReadTestDataFromJson<ProfileAboutMeTestModel>("C:\\ICProject\\AdvancedSpecFlow\\MarsAdvancedSpecflow\\SpecflowAutomation\\JsonData\\ProfileUserData.json");
            foreach (var profile in ProfileUserData)
            {
                string addedUserName = profileAboutMeObj.getVerifyUserName();
                string expectedUsername = profile.firstname + " " + profile.lastname;
                Assert.AreEqual(expectedUsername, addedUserName, "Actual Username do not match");
            }
        }
        
        public void userProfileAssert()
        {
           string  message = profileAboutMeObj.getSuccessMessage();
           string expectedMessage = "Availability updated";
           Assert.AreEqual(message, expectedMessage, "actual message and expected message do  match");
        }
    }
}
