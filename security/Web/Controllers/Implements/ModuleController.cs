using Bussines.Interface;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements
{
    [Route("api/module")]
    public class ModuleController : ControllerBase
    {
        private readonly IBModule _BModule;
        public ModuleController(IBModule BModule)
        {
            _BModule = BModule;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleDto>> GetById(int Id)
        {
            var result = await _BModule.GetById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _BModule.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ModuleDto>> Save([FromBody] ModuleDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _BModule.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ModuleDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _BModule.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _BModule.Delete(id);
            return NoContent();
        }
    }
}
