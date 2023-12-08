using SpecflowAutomation.Pages.Components.signIn;
using SpecflowAutomation.Pages;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SpecflowAutomation.TestModel;

namespace SpecflowAutomation.Process
{
    public class LoginProcess : Base
    {
#pragma warning disable
        LoginComponent loginComponentObj;
        Jsonhelper jsonhelperObj;

        public LoginProcess()
        {
            loginComponentObj = new LoginComponent();
            jsonhelperObj = new Jsonhelper();


        }
        public void doLogin(LoginTestModel data)
        {
            loginComponentObj.validLogin(data);
        }
        public void InvalidPassProcess(LoginTestModel data)
        {
            loginComponentObj.validUserInvalidPassword(data);
        }
        public void invalidUsernameProcess(LoginTestModel data) 
        {
            loginComponentObj.invalidUsernameValidPassword(data);
        }
    }
}
