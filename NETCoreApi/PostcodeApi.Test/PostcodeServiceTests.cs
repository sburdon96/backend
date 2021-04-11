using System;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using PostcodeApi.Application;
using PostcodeApi.Domain;

namespace PostcodeApi.Test
{
    public class Tests
    {
        [Test]
        public void WhenResponseIsSuccess_ReturnPostcodeResponse()
        {
            var expectedResponse = new PostcodeResponse
            {
                Result = new LocationData
                {
                    Latitude = 1,
                    Longitude = 1
                }
            };

            var json = JsonConvert.SerializeObject(expectedResponse);

            var httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = HttpStatusCode.OK;
            httpResponse.Content = new StringContent(json);

            var mockMapper = new Mock<IPostcodeIoApiWrapper>();
            mockMapper.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(httpResponse);

            var sut = new PostcodeService(mockMapper.Object);

            var result = sut.GetPostcodeLocation("NG15AD");

            using (new AssertionScope())
            {
                result.Result.Should().BeEquivalentTo(expectedResponse);
            }
        }

        [Test]
        public void WhenResponseIs404_ThrowException()
        {
            var httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = HttpStatusCode.NotFound;

            var mockMapper = new Mock<IPostcodeIoApiWrapper>();
            mockMapper.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(httpResponse);

            var sut = new PostcodeService(mockMapper.Object);

            Action action = async () => await sut.GetPostcodeLocation("IIIIII");

            using (new AssertionScope())
            {
                action.Should().Throw<Exception>();
            }
        }
    }
}