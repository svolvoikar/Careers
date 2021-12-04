using Newtonsoft.Json;
using System;

namespace TEK_Careers.API.Models.ResponseModels
{
    public class JobResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("locationName")]
        public string LocationName { get; set; }

        [JsonProperty("departmentName")]
        public string DepartmentName { get; set; }

        [JsonProperty("postedDate")]
        public DateTime PostedDate { get; set; }

        [JsonProperty("closingDate")]
        public DateTime ClosingDate { get; set; }

    }
}