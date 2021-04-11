using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PostcodeApi.Domain;

namespace PostcodeApi.Application
{
    public class PostcodeIoApiWrapper : IPostcodeIoApiWrapper
    {
        public async Task<HttpResponseMessage> Get(string postcode)
        {
            using (var client = new HttpClient())
            {
                return await client.GetAsync($"https://api.postcodes.io/postcodes/{postcode}");
            }
        }
    }
}
