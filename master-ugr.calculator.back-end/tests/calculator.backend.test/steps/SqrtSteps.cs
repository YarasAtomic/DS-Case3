using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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
        public void WhenRootIsCalculated(int number)
        {
            using (var client = new HttpClient())
            {
                var urlBase = _scenarioContext.Get<string>("urlBase");
                var url = $"{urlBase}/api/Calculator/";
                var api_call = $"{url}sqrt?number={number}";
                var response = client.GetAsync(api_call).Result;
                response.EnsureSuccessStatusCode();
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var jsonDocument = JsonDocument.Parse(responseBody);
                var result = jsonDocument.RootElement.GetProperty("result").GetString();

                var res = double.TryParse(result, out double n) ? n : double.NaN;

                _scenarioContext.Add("sqrt", res);
            }
        }

        [Then(@"its square root is (.*)")]
        public void ThenTheResultForItsSqrt(double sqrt_result)
        {
            var sqrt = _scenarioContext.Get<double>("sqrt");
            Assert.Equal(sqrt, sqrt_result);
        }
    }
}
