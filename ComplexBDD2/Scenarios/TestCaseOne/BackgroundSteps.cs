// THESE ARE STEPS RAN BEFORE EACH SCENARIO FOR THIS SPECIFIC FEATURE

using System;
using TechTalk.SpecFlow;
using System.IO;

namespace ComplexStateBDD.Scenarios.TestCaseOne
{
    [Binding, Scope(Feature = "TestCaseOne")]
    public class BackgroundSteps
    {

        // Using Context Injection
        private readonly FeatureContext featureContext;
        private readonly ScenarioContext scenarioContext;

        //private readonly BaseSteps mybase;

        private string KEY = "hdHUD839yhfdakj20190nHD8933y1612hpJSD9828";
        private string ENVIRONMENT = "Testing";
        private string COMPANY = "INCEDO";
        private string CLIENT = "CAMBRIDGE ASSOCIATES";

        public BackgroundSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
        }

        [Obsolete]
        [Given(@"I perform this condition")]
        public void GivenIPerformThisCondition()
        {
            // Available for all scenarios in this feature file (using feature.context)
            FeatureContext.Current["KEY"] = KEY;
            FeatureContext.Current["ENVIRONMENT"] = ENVIRONMENT;
            FeatureContext.Current["COMPANY"] = COMPANY;
            FeatureContext.Current["CLIENT"] = CLIENT;

            // using context injection
            featureContext["_KEY"] = KEY;
            featureContext["_ENVIRONMENT"] = ENVIRONMENT;
            featureContext["_COMPANY"] = COMPANY;
            featureContext["_CLIENT"] = CLIENT;
        }
        
        [Obsolete]
        [Given(@"I perform this other condition")]
        public void GivenIPerformThisOtherCondition()
        {
        
        }
    }
}
