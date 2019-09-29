using api_specflow.Model;
using api_specflow.Utilities;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace api_specflow
{
    [Binding]
    public class GetProductsSteps
    {
        private Settings _settings;

        public GetProductsSteps(Settings settings) => _settings = settings;

        [Given(@"I perform GET operation for '(.*)'")]
        public void GivenIPerformGETOperationFor(string url)
        {
            _settings.RestClient.BaseUrl = new System.Uri("http://localhost:3000/");
            _settings.Request = new RestRequest(url, Method.GET);
        }

        [Given(@"I perform operation for product (.*)")]
        public void GivenIPerformOperationForProduct(int id)
        {
            _settings.Request.AddUrlSegment("productid", id.ToString());

            _settings.Response = _settings.RestClient.ExecuteAsyncRequest<Products>(_settings.Request).GetAwaiter().GetResult();
        }

        [Then(@"I should see the '(.*)' as '(.*)'")]
        public void ThenIShouldSeeTheAs(string key, string pair)
        {
            Assert.That(_settings.Response.GetResponseObject(key), Is.EqualTo(pair), "That is the wrong name");
        }
    }
}