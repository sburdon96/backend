using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostcodeApi.Application;

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
            return Ok(await _postcodeService.GetPostcodeLocation(postcode));
        }
    }
}