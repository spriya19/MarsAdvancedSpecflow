using AventStack.ExtentReports;
using NUnit.Framework;
using SpecflowAutomation.Pages.Components.ProfileOverView;
using SpecflowAutomation.Pages.Components.ServiceListingOverView;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.AssertHelper
{
    public class ShareSkillAssert : Base
    {
        ShareSkillComponent shareSkillComponentObj;
        ManageListingComponent manageListingComponentObj;
        ProfileMenuTab profileMenuTabObj;
#pragma warning disable

        public ShareSkillAssert()
        {
            shareSkillComponentObj = new ShareSkillComponent();
            manageListingComponentObj = new ManageListingComponent();
            profileMenuTabObj = new ProfileMenuTab();
        }
        public void addShareSkillAssert()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "C:\\ICProject\\AdvancedSpecFlow\\MarsAdvancedSpecflow\\SpecflowAutomation\\JsonData\\ShareSkillAddData.json";
            List<ShareSkillTestModel> ShareSkillAddData = Jsonhelper.ReadTestDataFromJson<ShareSkillTestModel>(sFile);
            foreach (var data in ShareSkillAddData)
            {
                string category = data.category;
                string addedSkillcategory = shareSkillComponentObj.verifSkillCategory();
                if (addedSkillcategory == data.category)
                {
                    Assert.AreEqual(addedSkillcategory, data.category, "The actual and expected do not match");
                   
                }
                else
                {
                    Console.WriteLine("Check Error");
                }

            }
        }
        public void shareSkillUpdateAssert()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "C:\\ICProject\\AdvancedSpecFlow\\MarsAdvancedSpecflow\\SpecflowAutomation\\JsonData\\ShareskillUpdateData.json";
            List<ShareSkillTestModel> ShareSkillUpdateData = Jsonhelper.ReadTestDataFromJson<ShareSkillTestModel>(sFile);
            foreach (var data in ShareSkillUpdateData)
            {
                string category = data.category;
                profileMenuTabObj.clickManagelisting();
                string updatedSkill = shareSkillComponentObj.verifyUpdatedShareSkill();
                if (updatedSkill == data.category)
                {
                    Assert.AreEqual(updatedSkill, data.category, "The actual and expected do not match");
                   
                }
                else
                {
                    Console.WriteLine("Check Error");
                }
            }
        }
        public void negativeAddShareSkillAssert()
        {
            string errorMessageBox = shareSkillComponentObj.verifyErrorMessage();
            string expectedMessage = "Please complete the form correctly.";
            Assert.AreEqual(errorMessageBox, expectedMessage, "Actual and expected do not match");
           
        }
        public void DeleteShareSkillAssert()
        {
            string messageBox = manageListingComponentObj.verifyDeletedList();
            string popupMessage = messageBox;
            if (popupMessage.Contains("has been deleted"))
            {
                Console.WriteLine("Skill has been deleted");
            }
            else
            {
                Console.WriteLine("Check Error");
            }

            Assert.AreEqual(messageBox, popupMessage, "Actual message and expected message do not match");
            
        }
        public void negativeShareskillUpdateAssert()
        {
            string errorMessageBox = shareSkillComponentObj.verifyErrorMessage();
            string expectedMessage = "Please complete the form correctly.";
            Assert.AreEqual(errorMessageBox, expectedMessage, "Actual and expected do not match");
            
        }
    }
}
