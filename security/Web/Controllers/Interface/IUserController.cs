using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IUserController
    {
        Task<ActionResult<UserDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<UserDto>> Save([FromBody] UserDto entity);
        Task<IActionResult> Update(int id, [FromBody] UserDto entity);
    }
}
