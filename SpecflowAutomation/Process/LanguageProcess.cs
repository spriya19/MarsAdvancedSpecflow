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
    public class LanguageProcess : Base
    {
        ProfileMenuTab profileMenuTabObj;
        LanguageComponent languageComponentObj;
        public LanguageProcess()
        {
            profileMenuTabObj = new ProfileMenuTab();
            languageComponentObj = new LanguageComponent();
        }
        public void ClearLanguageProcess()
        {
            profileMenuTabObj.clickLanguageTab();
            languageComponentObj.clearExistingdata();
        }
        public void languageAddProcess(LanguageTestModel data)
        {
            profileMenuTabObj.clickLanguageTab();
            languageComponentObj.addNewLanguage(data);
        }
        public void languageUpdateProcess(LanguageTestModel data) 
        {
            profileMenuTabObj.clickLanguageTab();
            profileMenuTabObj.clickLanguageEditIcon();
            languageComponentObj.editLanguage(data);
        }
        public void languageDeleteProcess(string language)
        {
            profileMenuTabObj.clickLanguageTab();
            languageComponentObj.deleteLanguageData(language);
        }
        public void languageAddNegativeProcess(LanguageTestModel data)
        {
            profileMenuTabObj.clickLanguageTab();
            languageComponentObj.addNegativeLanguage(data);
        }
        public void languageUpdatedNegativeProcess(LanguageTestModel data)
        {
            profileMenuTabObj.clickLanguageTab();
            profileMenuTabObj.clickLanguageEditIcon();
            languageComponentObj.negtiveEditLanguage(data);
        }
    }
}
