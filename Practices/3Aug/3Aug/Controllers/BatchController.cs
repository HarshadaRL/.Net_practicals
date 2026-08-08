using _3Aug.Models;
using _3Aug.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchService _service;

        public BatchController(IBatchService service)
        {
            this._service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetBatches());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var batch = _service.GetBatch(id);

            if (batch == null)
                return NotFound("batch not found");
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

        [HttpPut("{Id}")]

        public IActionResult Put(int id, Batch batch)
        {
            if (id != batch.Id)
            {
                return BadRequest("Id mismatch");
            }

            _service.UpdateBatch(id, batch);

            return Ok(batch);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var batch= _service.GetBatch(id);

            if (batch == null)
            {
                return NotFound("batch not found");
            }

            _service.DeleteBatch(id);

            return Ok("Batch deleted successfully");
        }
    }
}
