using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PostcodeApi.Domain;

namespace PostcodeApi.Application
{
    public class PostcodeIoApiWrapper : IPostcodeIoApiWrapper
    {
        public async Task<PostcodeResponse> Get(string postcode)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://api.postcodes.io/postcodes/{postcode}");

                var result = JsonConvert.DeserializeObject<PostcodeResponse>(response.Content.ReadAsStringAsync()
                    .Result);

                return result;
            }
        }
    }
}
