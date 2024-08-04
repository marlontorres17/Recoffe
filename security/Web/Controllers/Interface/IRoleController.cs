using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IRoleController
    {
        Task<ActionResult<RoleDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<RoleDto>> Save([FromBody] RoleDto entity);
        Task<IActionResult> Update(int id, [FromBody] RoleDto entity);
    }
}
