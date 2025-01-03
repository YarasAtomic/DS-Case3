using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace calculator.lib.test.steps
{
    [Binding]
    public class SqrtSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public SqrtSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
/*
        [Given(@"a number (.*)")]
        public void GivenANumber(int number)
        {
            _scenarioContext.Add("number", number);
        }*/

        [When("I check it's square root")]
        [When("I calculate the square root")]
        public void ICheckItsSqrt()
        {
            var number = _scenarioContext.Get<int>("number");
            var sqrt = NumberAttributter.Sqrt(number);
            _scenarioContext.Add("result", sqrt);
        }

        [Then("it should be odd (.*)")]
        public void ThenTheSqrtShouldBe(double expected)
        {
            var sqrt = _scenarioContext.Get<double>("result");
            Assert.Equal(expected, sqrt);
        }
    }
}