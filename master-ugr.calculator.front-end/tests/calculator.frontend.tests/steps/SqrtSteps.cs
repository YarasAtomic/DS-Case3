using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Playwright;
using TechTalk.SpecFlow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace calculator.frontend.tests.steps
{
    [Binding]
    public class SqrtSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public SqrtSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"root of number (.*) is calculated")]
        public async Task WhenRootIsCalculated(int number)
        {
            IPage page = _scenarioContext.Get<IPage>("page");
            var base_url = _scenarioContext.Get<string>("urlBase");
            await page.GotoAsync($"{base_url}/Attribute");
            await page.FillAsync("#number", number.ToString());
            await page.ClickAsync("#attribute");
        }

        [Then(@"its square root is (.*)")]
        public async Task ThenTheResultForItsSqrt(string sqrt_result)
        {
            var page = (IPage)_scenarioContext["page"];
            var resultText = await page.InnerTextAsync("#sqrt");
            var americanDouble = sqrt_result.Replace(",", ".");
            var latinDouble = sqrt_result.Replace(".", ",");
            var ok = sqrt_result.Equals(americanDouble) || sqrt_result.Equals(latinDouble);
            Assert.True(ok, $"expected {sqrt_result} but actual {resultText}");
        }
    }
}
