using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Reporter;

namespace SpecflowAutomation.Hooks
{
   
[Binding]
    public sealed class ExtentHooks
    {
#pragma warning disable
        private static ExtentTest _feature;
        private static ExtentTest _scenario;
        private static ExtentReports _extent;
 private static ExtentSparkReporter htmlReporter;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentSparkReporter("C:\\ICProject\\AdvancedSpecFlow\\MarsAdvancedSpecflow\\SpecflowAutomation\\Hooks\\ExtentReport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
            }
            else
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text)?.Fail(scenarioContext.TestError.InnerException);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text)?.Fail(scenarioContext.TestError.InnerException);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text)?.Fail(scenarioContext.TestError.Message);
            }
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            _extent.Flush();
        }
    }
}

