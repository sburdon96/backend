using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PostcodeApi.Domain
{
    public class PostcodeList
    {
        [JsonProperty("postcodes")]
        public List<string> Postcodes { get; set; }
    }
}
