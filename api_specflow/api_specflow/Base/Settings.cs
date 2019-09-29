using api_specflow.Model;
using RestSharp;
using System;

namespace api_specflow
{
    public class Settings
    {
        public Uri BaseUrl { get; set; }
        public IRestResponse<Products> Response { get; set; }
        public IRestRequest Request { get; set; }
        public RestClient RestClient { get; set; } = new RestClient();
    }
}