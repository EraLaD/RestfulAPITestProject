using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestfulAPITestProject.APIModels
{
    public class APIResponseModel
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public DataInfoApiResponse? data { get; set; }

        public JsonElement? createdAt { get; set; }
        public JsonElement? updatedAt { get; set; }

        public string? message { get; set; }
    }
    public class DataInfoApiResponse
    {

        public string? color { get; set; }
        public string? capacity { get; set; }
        public int? capacityGB { get; set; }
        public float? price { get; set; }
        public string? generation { get; set; }
        public int? year { get; set; }
        public string? CPUmodel { get; set; }
        public string? Harddisksize { get; set; }
        public string? StrapColour { get; set; }
        public string? CaseSize { get; set; }
        public string? Description { get; set; }
        public float? Screensize { get; set; }

    }
}
