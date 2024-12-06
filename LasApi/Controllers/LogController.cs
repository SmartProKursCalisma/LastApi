using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        [HttpGet]
        public IActionResult CreateLog([FromQuery]string log)
        {
            Debug.WriteLine(log);
            return Ok();
        }
    }
}
