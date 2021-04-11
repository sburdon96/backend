using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PostcodeApi.Domain;

namespace PostcodeApi.Application
{
    public interface IPostcodeService
    {
        Task<PostcodeResponse> GetPostcodeLocation(string postcode);

        Task<PostcodesResponse> GetMultiplePostcodeLocation(PostcodeList postcodes);
    }
}
