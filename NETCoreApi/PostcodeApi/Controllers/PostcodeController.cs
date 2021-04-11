using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostcodeApi.Application;
using PostcodeApi.Application.Exceptions;
using PostcodeApi.Domain;

namespace PostcodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostcodeController : ControllerBase
    {
        private readonly IPostcodeService _postcodeService;

        public PostcodeController(IPostcodeService postcodeService)
        {
            _postcodeService = postcodeService;
        }

        [HttpGet("{postcode}")]
        public async Task<IActionResult> Get(string postcode)
        {
            try
            {
                var response = await _postcodeService.GetPostcodeLocation(postcode);
                response.Postcode = postcode;
                return Ok(response);
            }
            catch (HttpStatusCodeException ex)
            {
                return StatusCode(ex.FailResponse.Status, ex.FailResponse);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PostcodeList postcodes)
        {
            try
            {
                return Ok(await _postcodeService.GetMultiplePostcodeLocation(postcodes));
            }
            catch (HttpStatusCodeException ex)
            {
                return StatusCode(ex.FailResponse.Status, ex.FailResponse);
            }
        }
    }
}