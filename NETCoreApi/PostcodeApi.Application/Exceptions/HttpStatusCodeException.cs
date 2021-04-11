using System;
using System.Runtime.Serialization;
using PostcodeApi.Domain;

namespace PostcodeApi.Application.Exceptions
{
    [Serializable]
    public class HttpStatusCodeException : Exception
    {
        public PostcodeFailResponse FailResponse;

        public HttpStatusCodeException(PostcodeFailResponse failResponse)
        {
            FailResponse = failResponse;
        }

        protected HttpStatusCodeException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
