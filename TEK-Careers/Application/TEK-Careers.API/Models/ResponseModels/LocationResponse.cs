using Newtonsoft.Json;

namespace TEK_Careers.API.Models.ResponseModels
{
    public class LocationResponse
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
}