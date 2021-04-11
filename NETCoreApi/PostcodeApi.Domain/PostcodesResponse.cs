using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PostcodeApi.Domain
{
    public class PostcodesResponse
    {
        [JsonProperty("result")]
        public List<PostcodeResponse> Result { get; set; }
    }
}
