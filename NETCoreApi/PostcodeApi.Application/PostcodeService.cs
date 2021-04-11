﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
                throw new Exception();
            }

            return JsonConvert.DeserializeObject<PostcodeResponse>(apiResponse.Content.ReadAsStringAsync().Result);
        }
    }
}
