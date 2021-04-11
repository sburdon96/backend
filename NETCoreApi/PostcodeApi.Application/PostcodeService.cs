using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PostcodeApi.Application.Exceptions;
using PostcodeApi.Domain;

namespace PostcodeApi.Application
{
    public class PostcodeService : IPostcodeService
    {
        private readonly IPostcodeIoApiWrapper _wrapper;

        public PostcodeService(IPostcodeIoApiWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public async Task<PostcodeResponse> GetPostcodeLocation(string postcode)
        {
            var apiResponse = await _wrapper.Get(postcode);

            if (!apiResponse.IsSuccessStatusCode)
            {
                var failResponse = JsonConvert.DeserializeObject<PostcodeFailResponse>(apiResponse.Content.ReadAsStringAsync()
                    .Result);

                throw new HttpStatusCodeException(failResponse);
            }

            return JsonConvert.DeserializeObject<PostcodeResponse>(apiResponse.Content.ReadAsStringAsync().Result);
        }
    }
}
