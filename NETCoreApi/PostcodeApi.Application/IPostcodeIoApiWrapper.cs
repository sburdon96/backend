using PostcodeApi.Domain;

namespace PostcodeApi.Application
{
    public interface IPostcodeIoApiWrapper
    {
        PostcodeResponse Get();
    }
}
