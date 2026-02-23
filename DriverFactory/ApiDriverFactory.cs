using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RestfulAPITestProject.DriverFactory
{
    public class ApiDriverFactory
    {
        public RestClient GetRestClient(string baseUrl)
        {
            const int timeoutConst = 5000;
            var options = new RestClientOptions(baseUrl)
            {
                ThrowOnAnyError = false,
                Timeout = TimeSpan.FromMilliseconds(timeoutConst),
                FollowRedirects = true
            };

            return new RestClient(options);
        }
    }

}
