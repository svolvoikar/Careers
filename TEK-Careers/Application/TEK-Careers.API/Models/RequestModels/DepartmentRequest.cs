using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEK_Careers.API.Models.RequestModels
{
    public class DepartmentRequest
    {
        [JsonProperty("title")]
        public string Title { get; set; }

    }
}