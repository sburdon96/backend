using Newtonsoft.Json;

namespace PostcodeApi.Domain
{
    public class PostcodeFailResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
