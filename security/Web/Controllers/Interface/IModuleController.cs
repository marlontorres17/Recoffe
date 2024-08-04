using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IModuleController
    {
        Task<ActionResult<ModuleDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<ModuleDto>> Save([FromBody] ModuleDto entity);
        Task<IActionResult> Update(int id, [FromBody] ModuleDto entity);
    }
}
