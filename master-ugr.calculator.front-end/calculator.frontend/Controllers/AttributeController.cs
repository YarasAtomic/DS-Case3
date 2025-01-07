using calculator.frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace calculator.frontend.Controllers
{
    public class AttributeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private string base_url =
            Environment.GetEnvironmentVariable("CALCULATOR_BACKEND_URL") ??
            "https://pabloqr-calculadora-backend-uat.azurewebsites.net";
        const string api = "api/Calculator";
        private AttributeModel ExecuteOperation(string number)
        {
            AttributeModel model = new();
            var clientHandler = new HttpClientHandler();
            var client = new HttpClient(clientHandler);
            var url = $"{base_url}/api/Calculator/number_attribute?number={number}";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
            };
            using (var response = client.Send(request))
            {
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadAsStringAsync().Result;
                var json = JObject.Parse(body);
                var prime = json["prime"];
                var odd = json["odd"];
                if (prime != null)
                {
                    model.SetPrime(prime.Value<bool>());
                }
                if (odd != null)
                {
                    model.SetOdd(odd.Value<bool>());
                }
            }

            return model;
        }
        [HttpPost]
        public ActionResult Index(string number)
        {
            var result = ExecuteOperation(number);
            ViewBag.IsPrime = result.IsPrime();
            ViewBag.IsOdd = result.IsOdd();
            return View();
        }
    }
}
