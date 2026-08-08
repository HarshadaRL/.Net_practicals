using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _30July.Models;
namespace _30July.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBatches() {
            var batches = new List<Batch>
            {
                new Batch {Id= 1101, BatchName="A"},
                new Batch {Id= 1102, BatchName="B"},


            };

              return Ok(batches);
            }
    }
}
