using Bussines.Interface;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IBUser _BUser;
        public UserController(IBUser BUser)
        {
            _BUser = BUser;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int Id)
        {
            var result = await _BUser.GetById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _BUser.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Save([FromBody] UserDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _BUser.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _BUser.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _BUser.Delete(id);
            return NoContent();
        }
    }
}
