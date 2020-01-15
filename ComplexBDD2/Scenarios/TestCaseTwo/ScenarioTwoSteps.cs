using System;
using TechTalk.SpecFlow;

namespace ComplexStateBDD.Scenarios.TestCaseTwo
{
    [Binding, Scope(Feature = "TestCaseTwo", Tag = "test2")]
    public class ScenarioTwoSteps
    {
        // Using Context Injection
        private readonly FeatureContext featureContext;
        private readonly ScenarioContext scenarioContext;
        private readonly SharedSteps shared;

        public ScenarioTwoSteps(FeatureContext featureContext, ScenarioContext scenarioContext, SharedSteps shared)
        {
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
            this.shared = shared;
        }

        [Obsolete]
        [Given(@"I add user information to database")]
        public void GivenIAddUserInformationToDatabase()
        {

        }

        [Obsolete]
        [Given(@"I add an extra payroll")]
        public void GivenIAddAnExtraPayroll(Table table)
        {

        }

        [Obsolete]
        [Given(@"I access database")]
        public void GivenIAccessDatabase()
        {

        }

        [Obsolete]
        [When(@"I retrieve user information")]
        public void WhenIRetrieveUserInformation()
        {

        }

        [Obsolete]
        [When(@"I update user information")]
        public void WhenIUpdateUserInformation()
        {

        }

        [Obsolete]
        [Then(@"I validate user information")]
        public void ThenIValidateUserInformation()
        {

        }
    }
}
