using NUnit.Framework;
using SpecflowAutomation.Pages.Components.ProfileOverView;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Process
{
    public class ProfileAboutMeProcess
    {
#pragma warning disable
        ProfileAboutMe profileAboutMeObj;
        ProfileMenuTab profileMenuTabObj;

        public ProfileAboutMeProcess()
        {
            profileAboutMeObj = new ProfileAboutMe();
            profileMenuTabObj = new ProfileMenuTab();
        }
        public void updateUserName(ProfileAboutMeTestModel data)
        {
            profileMenuTabObj.clickUserNameIcon();
            profileAboutMeObj.usernameAvailabilityDetails(data);
        }
        public void updateAvailabilityType(ProfileAboutMeTestModel data)
        {
            profileMenuTabObj.clickAvailabilityEditBtn();
            profileAboutMeObj.addAndUpdateAvailabilityDetails(data);
        }
        public void updateAvailabilityHours(ProfileAboutMeTestModel data)
        {
            profileMenuTabObj.clickHoursEditBtn();
            profileAboutMeObj.addAndUpdateHourDetails(data);
        }
        public void updatedAvailabilityEarnTarget(ProfileAboutMeTestModel data)
        {
            profileMenuTabObj.clickEarnTargetEditBtn();
            profileAboutMeObj.addAndUpdateAvailabilityTargetDetails(data);
        }

    }
}
