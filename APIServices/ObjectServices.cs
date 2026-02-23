using RestfulAPITestProject.APIModels;
using RestfulAPITestProject.DriverFactory;
using RestfulAPITestProject.Utils;
using RestfulAPITestProject.Support;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestfulAPITestProject.APIServices
{
    public class ObjectServices
    {
        private readonly RestClient restClient;
        public BasicServices basicServices;
        public ObjectServices()
        {
            restClient = new ApiDriverFactory().GetRestClient(BaseUrl.GetBaseUrl());
            basicServices = new BasicServices();
        }
        public async Task<RestResponse<List<APIResponseModel>>> GetListOfAllObjects(string[]? ids = null)
        {
            var request = new RestRequest(ApiEndpoints.GetListOfAllObjects, Method.Get);
            // If any IDs are provided, add them as query parameters
            if (ids != null && ids.Length > 0)
            {
                foreach (var id in ids)
                {
                    request.AddQueryParameter("id", id);
                }
            }
            return await basicServices.ExecuteWithLogging<List<APIResponseModel>>(request);
        }
        public async Task<RestResponse<APIResponseModel>> GetObjectById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("id must be provided. Ensure object creation succeeded or use a test fixture.", nameof(id));

            var request = new RestRequest(ApiEndpoints.GetObjectById.Replace("{id}", id), Method.Get);
            return await basicServices.ExecuteWithLogging<APIResponseModel>(request);
        }
        public async Task<RestResponse<APIResponseModel>> AddObject(APIRequestModel newObjectCreated)
        {
            var request = new RestRequest(ApiEndpoints.AddObject, Method.Post);
            request.AddJsonBody(newObjectCreated);
            return await basicServices.ExecuteWithLogging<APIResponseModel>(request);
        }
        public async Task<RestResponse<APIResponseModel>> UpdateObjectById(string id, APIRequestModel updatedObject)
        {
            var request = new RestRequest(ApiEndpoints.UpdateObjectById.Replace("{id}", id), Method.Put);
            request.AddJsonBody(updatedObject);
            return await basicServices.ExecuteWithLogging<APIResponseModel>(request);
        }
        public async Task<RestResponse<APIResponseModel>> DeleteObjectById(string id)
        {
            var request = new RestRequest(ApiEndpoints.DeleteObjectById.Replace("{id}", id), Method.Delete);
            return await basicServices.ExecuteWithLogging<APIResponseModel>(request);
        }
    }
}
