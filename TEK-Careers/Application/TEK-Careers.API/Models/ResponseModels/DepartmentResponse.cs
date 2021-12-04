using Newtonsoft.Json;

namespace TEK_Careers.API.Models.ResponseModels
{
    public class DepartmentResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

}