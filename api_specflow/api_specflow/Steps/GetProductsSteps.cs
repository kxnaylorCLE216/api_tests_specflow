using api_specflow.Model;
using api_specflow.Utilities;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace api_specflow
{
    [Binding]
    public class GetProductsSteps
    {
        public RestClient client = new RestClient("http://localhost:3000/");
        public RestRequest request = new RestRequest();
        public IRestResponse<Products> response = new RestResponse<Products>();

        [Given(@"I perform GET operation for '(.*)'")]
        public void GivenIPerformGETOperationFor(string p0)
        {
            request = new RestRequest(p0, Method.GET);
        }

        [Given(@"I perform operation for product (.*)")]
        public void GivenIPerformOperationForProduct(int p0)
        {
            request.AddUrlSegment("productid", p0);

            response = client.ExecuteAsyncRequest<Products>(request).GetAwaiter().GetResult();
        }

        [Then(@"I should see the '(.*)' as '(.*)'")]
        public void ThenIShouldSeeTheAs(string p0, string p1)
        {
            Assert.That(response.GetResponseObject(p0), Is.EqualTo(p1), "That is the wrong name");
        }
    }
}