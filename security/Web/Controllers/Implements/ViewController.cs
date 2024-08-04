using Bussines.Interface;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements
{
    [Route("api/view")]
    public class ViewController : ControllerBase
    {
        private readonly IBView _BView;
        public ViewController(IBView BView)
        {
            _BView = BView;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ViewDto>> GetById(int Id)
        {
            var result = await _BView.GetById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _BView.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ViewDto>> Save([FromBody] ViewDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _BView.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ViewDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _BView.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _BView.Delete(id);
            return NoContent();
        }
    }
}
