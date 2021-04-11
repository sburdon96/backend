using Newtonsoft.Json;

namespace PostcodeApi.Domain
{
    public class LocationData
    {
        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }

        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }
    }
}
