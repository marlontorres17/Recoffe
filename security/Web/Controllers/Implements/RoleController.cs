using Bussines.Interface;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements
{
    [Route("api/role")]
    public class RoleController : ControllerBase
    {
        private readonly IBRole _BRole;
        public RoleController(IBRole BRole)
        {
            _BRole = BRole;
        }
       

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetById(int Id)
        {
            var result = await _BRole.GetById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _BRole.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RoleDto>> Save([FromBody] RoleDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _BRole.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoleDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _BRole.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _BRole.Delete(id);
            return NoContent();
        }
    }
}
