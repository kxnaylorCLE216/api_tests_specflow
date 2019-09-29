using api_specflow.Model;
using api_specflow.Utilities;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace api_specflow
{
    [Binding]
    public class PostProductSteps
    {
        private Settings _settings;

        public PostProductSteps(Settings settings) => _settings = settings;

        [Given(@"I Perform POST operation for '(.*)' with body")]
        public void GivenIPerformPOSTOperationForWithBody(string url, Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            _settings.Request = new RestRequest(url, Method.POST);

            _settings.Request.AddUrlSegment("productid", data.subproduct.ToString());

            _settings.Request.AddJsonBody(new
            {
                name = data.name
            });

            _settings.Response = _settings.RestClient.ExecuteAsyncRequest<Products>(_settings.Request).GetAwaiter().GetResult();
        }
    }
}