using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IRole_ViewController
    {
        Task<ActionResult<Role_ViewDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<Role_ViewDto>> Save([FromBody] Role_ViewDto entity);
        Task<IActionResult> Update(int id, [FromBody] Role_ViewDto entity);
    }
}
