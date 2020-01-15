// HOOKS OR BASE CLASS
// This is PARENT Hooks Class where we designate steps that must be ran for all Test (depending on the scope)

using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using System.Data.SqlClient;

namespace ComplexStateBDD.Scenarios
{
    [Binding]
    public class BaseSteps
    {
        // Using Context Injection
        private readonly FeatureContext featureContext;
        private readonly ScenarioContext scenarioContext;
        private readonly ScenarioStepContext stepContext;

        // generate visual report
        private static ExtentReports extent;
        private static ExtentTest scenario;
        private static ExtentTest feature;

        // write to file
        public static StreamWriter file = new StreamWriter(@"C:\Users\Sebastian\Desktop\app\ComplexBDD2\Output.txt");

        public BaseSteps(FeatureContext featureContext, ScenarioContext scenarioContext, ScenarioStepContext stepContext)
        {
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
            this.stepContext = stepContext;
        }

        // This will apply to all test run on test explorer
        [BeforeTestRun, Obsolete]
        public static void DoThisBeforeEachTestRun()
        {
            string message = "BEFORE TEST RUN";
            Console.WriteLine(message);
            file.WriteLine(message);

            // html visual report
            string reportsPath = @"C:\Users\Sebastian\Desktop\app\ComplexBDD2\ReportFiles\ExtentReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportsPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun, Obsolete]
        public static void DoThisAfterEachTestRun()
        {
            var message = "AFTER TEST RUN";
            Console.WriteLine(message);

            //html visual report
            extent.Flush();
        }

        // THis will apply to all features files in the feature folder
        [BeforeFeature, Obsolete]
        public static void DoThisBeforeEachFeature()
        {
            var message = "BEFORE FEATURE";
            Console.WriteLine(message);

            feature = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterFeature, Obsolete]
        public static void DoThisAfterEachFeature()
        {
            var message = "AFTER FEATURE";
            Console.WriteLine(message);
        }

        //this will apply to all scenarios in every feature file
        [BeforeScenario, Obsolete]
        public static void DoThisBeforeEachScenario()
        {
            var message = "BEFORE SCENARIO";
            Console.WriteLine(message);

            //html visual report
            //scenario = feature.createnode<scenario>(scenariocontext.scenarioinfo.title);
        }

        [AfterScenario, Obsolete]
        public static void DoThisAfterEachScenario()
        {
            var message = "AFTER SCENARIO";
            Console.WriteLine(message);
        }

        //This will apply to each step in each scenario of each feature file
        [BeforeStep, Obsolete]
        public static void DoThisBeforeEachStep()
        {
            var message = "BEFORE STEP";
            Console.WriteLine(message);
        }

        [AfterStep, Obsolete]
        public static void DoThisAfterEachStep()
        {
            var message = "AFTER STEP";
            Console.WriteLine(message);

            // html visual report
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            //    if (ScenarioContext.Current.TestError == null)
            //    {
            //        if (stepType == "Given")
            //        {
            //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
            //        }
            //        else if (stepType == "When")
            //        {
            //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
            //        }
            //        else if (stepType == "And")
            //        {
            //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
            //        }
            //        else if (stepType == "But")
            //        {
            //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
            //        }
            //        else if (stepType == "Then")
            //        {
            //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
            //        }
            //    }
            //    else if (ScenarioContext.Current.TestError != null)
            //    {
            //        if (stepType == "Given")
            //        {
            //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.StackTrace);
            //            //scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Source);
            //        }
            //        else if (stepType == "When")
            //        {
            //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.StackTrace);
            //            //scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Source);
            //        }
            //        else if (stepType == "Then")
            //        {
            //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.StackTrace);
            //            //scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Source);
            //        }
            //    }
            // skipped/pending steps
            if (ScenarioContext.Current.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                }
                if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                }
                if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                }
            }
        }
    }
}

