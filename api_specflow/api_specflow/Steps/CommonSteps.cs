using api_specflow.Model;
using api_specflow.Utilities;
using RestSharp;
using RestSharp.Authenticators;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace api_specflow.Steps
{
    [Binding]
    public class CommonSteps
    {
        private Settings _settings;

        public CommonSteps(Settings settings)
        {
            _settings = settings;
        }

        [Given(@"I get JWT authentication of User with following details")]
        public void GivenIGetJWTAuthenticationOfUserWithFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            _settings.Request = new RestRequest("auth/login", Method.POST);

            Auth auth = new Auth()
            {
                email = (string)data.Email,
                password = (string)data.Password
            };

            _settings.Request.AddJsonBody(auth);

            _settings.Response = _settings.RestClient.ExecutePostTaskAsync(_settings.Request).GetAwaiter().GetResult();
            var access_token = _settings.Response.GetResponseObject("access_token");

            var jwtAuth = new JwtAuthenticator(access_token);
            _settings.RestClient.Authenticator = jwtAuth;
        }
    }
}