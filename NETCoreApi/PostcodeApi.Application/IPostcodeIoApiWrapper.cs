using System.Net.Http;
using System.Threading.Tasks;
using PostcodeApi.Domain;

namespace PostcodeApi.Application
{
    public interface IPostcodeIoApiWrapper
    {
        Task<HttpResponseMessage> Get(string postcode);

        Task<HttpResponseMessage> Post(PostcodeList postcodes);
    }
}
