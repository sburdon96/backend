using System.Net.Http;
using System.Text;
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

        public async Task<HttpResponseMessage> Post(PostcodeList postcodes)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(postcodes);
                var postcodesData = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                return await client.PostAsync($"https://api.postcodes.io/postcodes/", postcodesData);
            }
        }
    }
}
