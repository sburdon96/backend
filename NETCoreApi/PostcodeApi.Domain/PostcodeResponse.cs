using System;
using Newtonsoft.Json;

namespace PostcodeApi.Domain
{
    public class PostcodeResponse
    {
        [JsonProperty("query")]
        public string Postcode { get; set; }

        [JsonProperty("result")]
        public LocationData Location { get; set; }
    }
}
