using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostcodeApi.Application;

namespace PostcodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostcodeController : ControllerBase
    {
        [HttpGet("{postcode}")]
        public async Task<IActionResult> Get(string postcode)
        {
            var wrapper = new PostcodeIoApiWrapper();
            return Ok(await wrapper.Get(postcode));
        }
    }
}