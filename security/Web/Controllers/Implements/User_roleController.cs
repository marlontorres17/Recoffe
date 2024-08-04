using Bussines.Interface;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements
{
    [Route("api/user_role")]
    public class User_roleController : ControllerBase
    {
        private readonly IBUser_role _BUser_role;
        public User_roleController(IBUser_role BUser_role)
        {
            _BUser_role = BUser_role;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User_roleDto>> GetById(int Id)
        {
            var result = await _BUser_role.GetById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _BUser_role.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<User_roleDto>> Save([FromBody] User_roleDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _BUser_role.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User_roleDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _BUser_role.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _BUser_role.Delete(id);
            return NoContent();
        }
    }
}
