using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Portfolio.Models
{
    public class Github
    {
        public string Url { get; set; }

        public static List<Github> GetHub()
        {
            var client = new RestClient("https://api.github.com/");

            var request = new RestRequest("/users/minhchan11/starred", Method.GET);
            request.AddHeader("User-Agent", "minhchan11");
            request.AddParameter("Authorization", "token 0133da5f5cd2306696e31977186c3fa695a9f68c", ParameterType.HttpHeader);

            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            var gitList = new List<Github>();
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            foreach (JObject singleResponse in jsonResponse)
                 {
                        var gitHub = JsonConvert.DeserializeObject<Github>(singleResponse.ToString());
                        gitList.Add(gitHub);
                 }
            return gitList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

    }
}
