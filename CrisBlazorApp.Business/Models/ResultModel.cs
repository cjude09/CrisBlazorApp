using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrisBlazorApp.Business.Models
{
    public class ResultModel<T>
    {
        [JsonProperty(PropertyName = "count", NullValueHandling = NullValueHandling.Ignore)]
        public int Count { get; set; }
        [JsonProperty(PropertyName = "next", NullValueHandling = NullValueHandling.Ignore)]
        public string Next { get; set; }
        [JsonProperty(PropertyName = "previous", NullValueHandling = NullValueHandling.Ignore)]
        public string Previous { get; set; }
        [JsonProperty(PropertyName = "results", NullValueHandling = NullValueHandling.Ignore)]
        public List<T> Results { get; set; }
    }
}
