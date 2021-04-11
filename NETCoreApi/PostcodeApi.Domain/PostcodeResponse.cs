using System;
using Newtonsoft.Json;

namespace PostcodeApi.Domain
{
    public class PostcodeResponse
    {
        [JsonProperty("result")]
        public LocationData Result { get; set; }
    }

    public class LocationData
    {
        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }

        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }
    }
}
