using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace api_specflow.Hooks
{
    [Binding]
    public class TestInitialize
    {
        private Settings _settings;

        public TestInitialize(Settings settings)
        {
            _settings = settings;
        }

        [BeforeScenario]
        public void TestSetup()
        {
            _settings.BaseUrl = new Uri(ConfigurationManager.AppSettings["baseUrl"].ToString());
            _settings.RestClient.BaseUrl = _settings.BaseUrl;
        }
    }
}