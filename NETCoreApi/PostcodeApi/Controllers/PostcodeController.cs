using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostcodeApi.Application;

namespace PostcodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostcodeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var wrapper = new PostcodeIoApiWrapper();
            return Ok(await wrapper.Get());
        }
    }
}