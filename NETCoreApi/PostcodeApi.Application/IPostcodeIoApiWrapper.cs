using System.Threading.Tasks;
using PostcodeApi.Domain;

namespace PostcodeApi.Application
{
    public interface IPostcodeIoApiWrapper
    {
        Task<PostcodeResponse> Get();
    }
}
