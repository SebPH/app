using System;
using TechTalk.SpecFlow;
using System.Data.SqlClient;

namespace ComplexStateBDD.Scenarios.TestCaseOne
{
    [Binding, Scope(Feature ="TestCaseOne", Tag ="test1")]
    public class ScenarioOneSteps
    {
        // Using Context Injection
        private readonly FeatureContext featureContext;
        private readonly ScenarioContext scenarioContext;
        private readonly SharedSteps shared;

        private string _name;
        private string _dob;
        private string _email;
        private string _department;

        public ScenarioOneSteps(FeatureContext featureContext, ScenarioContext scenarioContext, SharedSteps shared)
        {
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
            this.shared = shared;
        }

        [Obsolete]
        [When(@"I add user information to database (.*), (.*), (.*), (.*)")]
        public void WhenIAddUserInformationToDatabase(string name, string dob, string email, string department)
        {
            // Only Available for this Scenario
            ScenarioContext.Current["Name"] = name;
            ScenarioContext.Current["Dob"] = dob;
            ScenarioContext.Current["Email"] = email;
            ScenarioContext.Current["Department"] = department;

            // using context injection
            scenarioContext["_Name"] = name;
            scenarioContext["_Dob"] = dob;
            scenarioContext["_Email"] = email;
            scenarioContext["_Department"] = department;

            _name = name;
            _dob = dob;
            _email = email;
            _department = department;

            // Insert Query
            //query = "INSERT INTO Users (name, dob, email, department) VALUES (, 'admin', 'admin@ca.com', '', 0)";
            //command = new SqlCommand(query, conn);
            //command.ExecuteNonQuery();
            //Console.WriteLine("Item Inserted");

            //query = "EXEC InsertIntoUsers @name = " + name + ", @dob = " + dob + ", @email = " + email + ", @department = " + department;
            //command = new SqlCommand(query, conn);
            //command.ExecuteNonQuery();
            //Console.WriteLine("Item Inserted");

            //conn.Close();
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
