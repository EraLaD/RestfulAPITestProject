using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestfulAPITestProject.APIModels;

namespace RestfulAPITestProject.Support
{
    public static class TestData
    {

        public static APIRequestModel NewObject = new APIRequestModel
        {
            name = DataGenerator.GenerateDeviceName(),
            data = new DataInfoApiRequest
            {
                year = DataGenerator.GenerateYear(),
                price = DataGenerator.GeneratePrice(),
                CPUmodel = DataGenerator.GenerateCPUModel(),
                Harddisksize = DataGenerator.GenerateHardDiskSize()
            }
        };
        //name is updted and Description is added to the data object.
        public static APIRequestModel UpdatedObject(APIRequestModel existingObject)
        {
            return new APIRequestModel
            {
                name = "Updated version" + existingObject.name,
                data = new DataInfoApiRequest
                {
                    year = existingObject.data!.year,
                    price = existingObject.data!.price,
                    CPUmodel = existingObject.data!.CPUmodel,
                    Harddisksize = existingObject.data!.Harddisksize,
                    Description = DataGenerator.GenerateDescription()
                }
            };

        }
        public static string DeletedObjectResponse(string deletedObjectId)
        {
            return "Object with id = " + deletedObjectId + " has been deleted.";
        }

    }
}
