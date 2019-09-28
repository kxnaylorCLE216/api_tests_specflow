using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

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

            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);

            var name = output["name"];

            Assert.That(name,
                Is.EqualTo("Dyson Ball Animal Upright Vacuum"), "That is the wrong name");

        }


        [Test]
        public void PostWithAnoymousBody()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("products/{productid}", Method.GET);
            request.AddUrlSegment("productid", 1);

            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);

            var name = output["name"];

            Assert.That(name, 
                Is.EqualTo("Dyson Ball Animal Upright Vacuum"), "That is the wrong name");

        }
    }
}