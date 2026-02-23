using RestfulAPITestProject.APIModels;
using RestfulAPITestProject.APIServices;
using RestfulAPITestProject.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit.Priority;

namespace RestfulAPITestProject.APITests
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]//In order to execute the test in the Priority order.
    public class ApiTests
    {
        private readonly ObjectServices objectServices = new();
        private static string? newObjectId;
        private APIRequestModel newObject = TestData.NewObject;

        [Fact, Priority(1)]
        public async Task TestGetListOfAllObjectsSuccessfully()
        {
            var response = await objectServices.GetListOfAllObjects();

            // Deserialize the response content
            string? jsonContent = response.Content;
            if (jsonContent is not null)
            {
                var apiResponseContent = JsonSerializer.Deserialize<List<APIResponseModel>>(jsonContent);
                // Assert response status code is OK (200)
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                // Assert response content is not null or empty
                Assert.NotNull(apiResponseContent);
                Assert.NotEmpty(apiResponseContent!);


            }
        }
        [Fact, Priority(2)]
        public async Task TestAddNewObjectSuccessfully()
        {
            var response = await objectServices.AddObject(newObject);

            // Assert response status code is OK (200)
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Assert response content is not null
            var apiResponse = response.Data;
            Assert.NotNull(apiResponse);

            // Validate created object id
            Assert.NotNull(apiResponse!.id);
            Assert.NotEmpty(apiResponse.id);
            newObjectId = apiResponse.id;

            //Validate createdAt field is present and not null
            Assert.NotEmpty(apiResponse.createdAt?.ToString() ?? string.Empty);
            Assert.Equal(newObject.name, apiResponse.name);

            Assert.NotNull(newObject.data);
            Assert.NotNull(apiResponse.data);
            apiResponse.data.Should().BeEquivalentTo(newObject.data);
        }

        [Fact, Priority(3)]
        public async Task TestGetObjectByIdSuccessfully()
        {
            var response = await objectServices.GetObjectById(newObjectId!);

            // Asse}rt response status code is OK (200)
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Use RestSharp's strongly-typed deserialized content
            var apiResponse = response.Data;
            Assert.NotNull(apiResponse);

            // Validate retrieved object id matches the created object id
            Assert.Equal(newObjectId, apiResponse!.id);

            //Validate response content matches the created object
            Assert.NotNull(newObject.data);
            Assert.NotNull(apiResponse.data);
            apiResponse.data.Should().BeEquivalentTo(newObject.data);

        }
        [Fact, Priority(4)]
        public async Task TestUpdateAddedObjectSuccessfully()
        {
            APIRequestModel updatedObject = TestData.UpdatedObject(newObject);

            var response = await objectServices.UpdateObjectById(newObjectId!, updatedObject);

            // Assert response status code is OK (200)
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Assert response content is not null
            var apiResponse = response.Data;
            Assert.NotNull(apiResponse);

            //Validate updatedAt field is present and not null
            Assert.NotEmpty(apiResponse.updatedAt?.ToString() ?? string.Empty);
            Assert.Equal(updatedObject.name, apiResponse.name);

            Assert.NotNull(updatedObject.data);
            Assert.NotNull(apiResponse.data);
            apiResponse.data.Should().BeEquivalentTo(updatedObject.data);
        }
        [Fact, Priority(5)]
        public async Task TestDeleteAddedObjectSuccessfully()
        {
            var response = await objectServices.DeleteObjectById(newObjectId!);

            // Assert response status code is OK (200)
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Assert response content is not null
            var apiResponse = response.Data;
            Assert.NotNull(apiResponse);

            Assert.NotNull(apiResponse.message);
            Assert.Equal(TestData.DeletedObjectResponse(newObjectId!), apiResponse.message);
        }
    }
}
