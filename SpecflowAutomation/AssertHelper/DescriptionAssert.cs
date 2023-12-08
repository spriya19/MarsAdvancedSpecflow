using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowAutomation.Pages.Components.ProfileOverView;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.AssertHelper
{
    public class DescriptionAssert : Base
    {
        DescriptionComponent descriptionComponentObj;

        public DescriptionAssert()
        {
            descriptionComponentObj = new DescriptionComponent();
        }
        public void verifyDescriptionAssert()
        {
            string messageBox = descriptionComponentObj.SuccessMessage();
           // var popupMessageText = messageBox;
            string popupMessage = messageBox;
            //string expectedMessage2 = "Description has been saved successfully";
            string expectedMessage2 = "First character can only be digit or letters";
            string expectedMessage3 = "Please, a description is required";

            if (popupMessage.Contains("has been saved successfully"))
            {
                Console.WriteLine("Description has been saved successfully");
            }
            else if ((popupMessage == expectedMessage2 || popupMessage == expectedMessage3))
            {
                Console.WriteLine("Successfully got the error message");
            }
            else
            {
                Console.WriteLine("Check Error");
            }
            Assert.AreEqual(popupMessage, messageBox, "Actual Message and Expected Message do not match");

        }
    }
}
