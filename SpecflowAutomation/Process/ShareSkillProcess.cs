using AventStack.ExtentReports;
using SpecflowAutomation.Pages.Components.ProfileOverView;
using SpecflowAutomation.Pages.Components.ServiceListingOverView;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Process
{
    public class ShareSkillProcess : Base
    {
#pragma warning disable
        ShareSkillComponent shareSkillComponentObj;
        ProfileMenuTab profileMenuTabObj;
        ManageListingComponent manageListingComponentObj;


        public ShareSkillProcess()
        {
            shareSkillComponentObj = new ShareSkillComponent();
            profileMenuTabObj = new ProfileMenuTab();
            manageListingComponentObj = new ManageListingComponent();
        }
        public void addShareSkillDetails(ShareSkillTestModel skilladd)
        {
            profileMenuTabObj.clickProfileManageListing();
            shareSkillComponentObj.clearExistingShareskillData();
            profileMenuTabObj.clickOnShareSkillTab();
            shareSkillComponentObj.shareSkillAdd(skilladd);
        }
        public void shareSkillUpdate(ShareSkillTestModel skilladd)
        {
            profileMenuTabObj.clickProfileManageListing();
            profileMenuTabObj.clickEditManageListing();
            shareSkillComponentObj.EditShareSkill(skilladd);
        }
        public void shareSkillDeleteProcess(string Category)
        {
            profileMenuTabObj.clickProfileManageListing();
            manageListingComponentObj.deleteShareSkill(Category);
        }
        public void negativeAddShareSkillProcess(ShareSkillTestModel skilladd)
        {
            profileMenuTabObj.clickProfileManageListing();
            shareSkillComponentObj.clearExistingShareskillData();
            profileMenuTabObj.clickOnShareSkillTab();
            shareSkillComponentObj.negativeShareSkill(skilladd);
        }
        public void negativeShareskillUpdateProcess(ShareSkillTestModel skilladd)
        {
                profileMenuTabObj.clickProfileManageListing();
                profileMenuTabObj.clickEditManageListing();
                shareSkillComponentObj.negativeShareSkillUpdate(skilladd);
        }
    }

}

