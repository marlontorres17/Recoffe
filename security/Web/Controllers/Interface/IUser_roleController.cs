using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IUser_roleController
    {
        Task<ActionResult<User_roleDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<User_roleDto>> Save([FromBody] User_roleDto entity);
        Task<IActionResult> Update(int id, [FromBody] User_roleDto entity);
    }
}
