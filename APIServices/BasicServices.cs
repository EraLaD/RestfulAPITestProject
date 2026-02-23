using RestfulAPITestProject.DriverFactory;
using RestfulAPITestProject.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulAPITestProject.APIServices
{
    public class BasicServices
    {
        private readonly RestClient restClient;
        public BasicServices()
        {
            restClient = new ApiDriverFactory().GetRestClient(BaseUrl.GetBaseUrl());
        }
        public async Task<RestResponse<T>> ExecuteWithLogging<T>(RestRequest request) where T : notnull
        {
            var response = await restClient.ExecuteAsync<T>(request);

            if (!response.IsSuccessful)
            {
                Console.WriteLine($"URL: {restClient.BuildUri(request)}");
                Console.WriteLine($"Method: {request.Method}");
                Console.WriteLine($"Status: {response.StatusCode}");
                Console.WriteLine($"Content: {response.Content}");
            }

            return response;
        }
    }
}
