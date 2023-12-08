using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowAutomation.Hooks
{
    [Binding]
    public sealed class hooks : Base
    {
#pragma warning disable
        private static ExtentReports extent;
        private static ExtentTest testreport;
        private static ExtentSparkReporter htmlReporter;

        [BeforeScenario]

        public void BeforeScenarioWithTag()
        {
            SetupAuction();

        }
        [AfterScenario]
        public void AfterSCenario()
        {
            TearDownAction();
        }
        

    }
}
