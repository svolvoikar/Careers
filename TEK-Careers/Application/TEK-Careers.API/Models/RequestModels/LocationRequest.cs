using Newtonsoft.Json;

namespace TEK_Careers.API.Models.RequestModels
{
    public class LocationRequest
    {

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("zip")]
        public int Zip { get; set; }
    }
}