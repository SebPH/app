using System;
using TechTalk.SpecFlow;

namespace ComplexBDD2.Scenarios
{
    [Binding]
    public class DefaultSteps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            Console.WriteLine("Number: {0}", p0);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            Console.WriteLine("Press Add...");
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Console.WriteLine("Result: {0}", p0);
        }
    }
}
