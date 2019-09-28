using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_specflow.Utilities
{
    public static class Libraries
    {
        public static string GetRespnseObhect(this IRestResponse response, string responseOject)
        {
            JObject obs = JObject.Parse(response.Content);
            return obs[responseOject].ToString();
        }

        public static Dictionary<string, string> DeserializeResponse(this IRestResponse restResponse)
        {
            var deserialize = new JsonDeserializer();
            return deserialize.Deserialize<Dictionary<string, string>>(restResponse);
        }

        public static async Task<IRestResponse<T>> ExecuteAsyncRequest<T>(this RestClient client, IRestRequest request) where T : class, new()
        {
            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();

            client.ExecuteAsync<T>(request, restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    const string message = "Error retrieving response.";
                    throw new ApplicationException(message, restResponse.ErrorException);
                }

                taskCompletionSource.SetResult(restResponse);
            });

            return await taskCompletionSource.Task;
        }
    }
}