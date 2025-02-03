using Microsoft.AspNetCore.Mvc;

namespace nexox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new[] { "Value1", "Value2" });
        }

        // GET: api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Value{id}");
        }
    }
}
