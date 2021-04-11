using System;
using System.Threading.Tasks;
using PostcodeApi.Domain;

namespace PostcodeApi.Application
{
    public class PostcodeIoApiWrapper : IPostcodeIoApiWrapper
    {
        public Task<PostcodeResponse> Get()
        {
            throw new NotImplementedException();
        }
    }
}
