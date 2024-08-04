using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IViewController
    {
        Task<ActionResult<ViewDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<ViewDto>> Save([FromBody] ViewDto entity);
        Task<IActionResult> Update(int id, [FromBody] ViewDto entity);
    }
}
