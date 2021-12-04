using Newtonsoft.Json;
using System;

namespace TEK_Careers.API.Models.ResponseModels
{
    public class LocationDetails
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("zip")]
        public long Zip { get; set; }
    }

    public class DepartmentDetails
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class JobDetailsResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("location")]
        public LocationDetails Location { get; set; }

        [JsonProperty("department")]
        public DepartmentDetails Department { get; set; }

        [JsonProperty("postedDate")]
        public DateTime PostedDate { get; set; }

        [JsonProperty("closingDate")]
        public DateTime ClosingDate { get; set; }
    }


}