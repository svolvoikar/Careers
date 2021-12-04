using Newtonsoft.Json;
using System;

namespace TEK_Careers.API.Models.RequestModels
{
    public class JobRequest
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("locationId")]
        public int LocationId { get; set; }

        [JsonProperty("departmentId")]
        public int DepartmentId { get; set; }

        [JsonProperty("postedDate")]
        public DateTime PostedDate { get; set; }

        [JsonProperty("closingDate")]
        public DateTime ClosingDate { get; set; }
    }
}