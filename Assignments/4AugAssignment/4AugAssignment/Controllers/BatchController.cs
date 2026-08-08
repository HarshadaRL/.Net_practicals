using _4AugAssignment.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _4AugAssignment.Models;

namespace _4AugAssignment.Controllers
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
        public IActionResult GetIdq(int id)
        {
            var batch = _service.GetBatch(id);
            if (batch == null)
                return NotFound("Batch not found");

            return Ok(batch);

        }

        [HttpPost]
        public IActionResult Add(Batch batch)
        {
            _service.AddBatch(batch);
            return Ok(batch);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Batch batch)
        {
            if (id != batch.Id)
                return BadRequest();

            var existing = _service.GetBatch(id);

            if (existing == null)
                return NotFound();

            _service.UpdateBatch(batch);
            return Ok(batch);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var batch = _service.GetBatch(id);

            if (batch == null)
                return NotFound();
            _service.DeleteBatch(id);

            return Ok(batch);
        }

    }
}
