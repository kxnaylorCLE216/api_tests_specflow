using NUnit.Framework;
using RestSharp;

namespace api_specflow
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("products/{productid}", Method.GET);
            request.AddUrlSegment("productid", 1);

            var content = client.Execute(request).Content;
        }
    }
}