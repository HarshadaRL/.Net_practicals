using _03Aug2026_Ass.Models;
using _03Aug2026_Ass.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _03Aug2026_Ass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchService _service;

        public BatchController(IBatchService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var batch = _service.GetBatch(id);

            if (batch == null)
                return NotFound("Batch not found");

            return Ok(batch);
        }

        [HttpPost]
        public IActionResult Post(Batch batch)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.AddBatch(batch);

            return Ok(batch);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Batch batch)
        {
            if (id != batch.Id)
                return BadRequest("Id mismatch");

            var existingBatch = _service.GetBatch(id);

            if (existingBatch == null)
                return NotFound("Batch not found");

            _service.UpdateBatch(batch);

            return Ok("Batch Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var batch = _service.GetBatch(id);

            if (batch == null)
                return NotFound("Batch not found");

            _service.DeleteBatch(id);

            return Ok("Batch Deleted");
        }
    }
}