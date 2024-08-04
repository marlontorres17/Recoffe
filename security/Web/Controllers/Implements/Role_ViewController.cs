using Bussines.Interface;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements
{
    [Route("api/role_view")]
    public class Role_ViewController : ControllerBase
    {
        private readonly IBRole_View _BRole_View;
        public Role_ViewController(IBRole_View BRole_View)
        {
            _BRole_View = BRole_View;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Role_ViewDto>> GetById(int Id)
        {
            var result = await _BRole_View.GetById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _BRole_View.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Role_ViewDto>> Save([FromBody] Role_ViewDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _BRole_View.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Role_ViewDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _BRole_View.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _BRole_View.Delete(id);
            return NoContent();
        }
    }
}
