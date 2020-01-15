using System;
using TechTalk.SpecFlow;

namespace ComplexStateBDD.Scenarios.TestCaseTwo
{
    [Binding, Scope(Feature = "TestCaseTwo")]
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
            // Available for all scenarios in this feature file
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
            //mybase.message = "Background Initial Condition - 1";
            //Console.WriteLine(mybase.message);
            //mybase.file.WriteLine(mybase.message);
        }
    }
}
