using System;
using Newtonsoft.Json;

namespace PostcodeApi.Domain
{
    public class PostcodeResponse
    {
        [JsonProperty("result")]
        public LocationData Result { get; set; }
    }
}
