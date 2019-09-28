using api_specflow.Model;
using api_specflow.Utilities;
using NUnit.Framework;
using RestSharp;

namespace api_specflow
{
    [TestFixture]
    public class UnitTest1
    {
        private RestClient client;
        private int id;

        [SetUp]
        public void setUp()
        {
            client = new RestClient("http://localhost:3000/");
        }

        [Test]
        public void GetTheFirstProduct()
        {
            var request = new RestRequest("products/{productid}", Method.GET);
            request.AddUrlSegment("productid", 1);

            var response = client.Execute(request);

            string name = response.GetResponseObject("name");

            Assert.That(name, Is.EqualTo("Dyson Ball Animal Upright Vacuum"), "That is the wrong name");
        }

        [Test]
        public void PostWithAnoymousBody()
        {
            var request = new RestRequest("products", Method.POST);

            request.AddJsonBody(new
            {
                name = "RockDove",
                cost = "19.99",
                quantity = 1000,
                locationId = 3,
                groupId = 1
            });

            var response = client.Execute(request);

            var result = response.DeserializeResponse()["cost"];

            Assert.That(result, Is.EqualTo("19.99"), "The Cost is not correct");
        }

        [Test]
        public void PostWihClassBody()
        {
            SetLastId();

            var request = new RestRequest("products", Method.POST);

            Products products = new Products()
            {
                id = id,
                name = "5 Pack Charcoal Toothbrush",
                cost = 5.99,
                quantity = 300,
                locationId = 2,
                groupId = 2
            };

            request.AddJsonBody(products);

            Products newProduct = client.Execute<Products>(request).Data;

            Assert.That(newProduct.cost, Is.EqualTo(5.99), "The Cost is not correct");
        }

        [Test]
        public void PostWihAsync()
        {
            SetLastId();

            var request = new RestRequest("products", Method.POST);

            Products products = new Products()
            {
                id = id,
                name = "Lisianthus Women Belt Buckle Fedora Hat",
                cost = 16.45,
                quantity = 300,
                locationId = 1,
                groupId = 1
            };

            request.AddJsonBody(products);

            var result = client.ExecuteAsyncRequest<Products>(request).GetAwaiter().GetResult();

            Assert.That(result.Data.cost, Is.EqualTo(16.45), "The Cost is not correct");
        }

        private void SetLastId()
        {
            var request = new RestRequest("products", Method.GET);

            var response = client.Execute(request);

            id = response.getLastID<Products>();
        }
    }
}