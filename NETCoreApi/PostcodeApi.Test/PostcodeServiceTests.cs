using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using PostcodeApi.Application;
using PostcodeApi.Application.Exceptions;
using PostcodeApi.Domain;

namespace PostcodeApi.Test
{
    public class Tests
    {
        [Test]
        public void WhenResponseIsSuccessForPostcode_ReturnPostcodeResponse()
        {
            var expectedResponse = new PostcodeResponse
            {
                Location = new LocationData
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
        public void WhenResponseIsNotSuccessForGet_ThrowException()
        {
            var expectedResponse = new PostcodeFailResponse()
            {
               Status = 404,
               Error = "Error"
            };
            var json = JsonConvert.SerializeObject(expectedResponse);

            var httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = HttpStatusCode.NotFound;
            httpResponse.Content = new StringContent(json);

            var mockMapper = new Mock<IPostcodeIoApiWrapper>();
            mockMapper.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(httpResponse);

            var sut = new PostcodeService(mockMapper.Object);

            Func<Task> action = async () => await sut.GetPostcodeLocation("IIIIII");

            using (new AssertionScope())
            {
                action.Should().Throw<HttpStatusCodeException>();
            }
        }

        [Test]
        public void WhenResponseIsSuccessForMultiplePostcodes_ReturnPostcodeResponse()
        {
            var expectedResponse = new PostcodesResponse
            {
                Result = new List<PostcodeResponse>
                {
                    new PostcodeResponse
                    {
                        Location = new LocationData
                        {
                            Latitude = 1,
                            Longitude = 1
                        }
                    },
                    new PostcodeResponse
                    {
                        Location = new LocationData
                        {
                            Latitude = 2,
                            Longitude = 2
                        }
                    }
                }
            };

            var json = JsonConvert.SerializeObject(expectedResponse);

            var httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = HttpStatusCode.OK;
            httpResponse.Content = new StringContent(json);

            var mockMapper = new Mock<IPostcodeIoApiWrapper>();
            mockMapper.Setup(x => x.Post(It.IsAny<PostcodeList>())).ReturnsAsync(httpResponse);

            var sut = new PostcodeService(mockMapper.Object);

            var result = sut.GetMultiplePostcodeLocation(new PostcodeList());

            using (new AssertionScope())
            {
                result.Result.Should().BeEquivalentTo(expectedResponse);
            }
        }

        [Test]
        public void WhenResponseIsNotSuccessForPost_ThrowException()
        {
            var expectedResponse = new PostcodeFailResponse()
            {
                Status = 404,
                Error = "Error"
            };
            var json = JsonConvert.SerializeObject(expectedResponse);

            var httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = HttpStatusCode.NotFound;
            httpResponse.Content = new StringContent(json);

            var mockMapper = new Mock<IPostcodeIoApiWrapper>();
            mockMapper.Setup(x => x.Post(It.IsAny<PostcodeList>())).ReturnsAsync(httpResponse);

            var sut = new PostcodeService(mockMapper.Object);

            Func<Task> action = async () => await sut.GetMultiplePostcodeLocation(new PostcodeList());

            using (new AssertionScope())
            {
                action.Should().Throw<HttpStatusCodeException>();
            }
        }
    }
}