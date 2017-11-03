using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
namespace PersonalSite.Models
{
    public class Project
    {
        public string full_name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Stars { get; set; }
        public string Language { get; set; }
        public DateTime LastUpdated {get;set;}

        public static List<Project> GetProjects()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.github.com/users/jstein92/starred");
            client.AddDefaultHeader("User-Agent", "Jstein92");
            var request = new RestRequest();
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var messageList = JsonConvert.DeserializeObject<List<Project>>(jsonResponse.ToString());
            return messageList;
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
