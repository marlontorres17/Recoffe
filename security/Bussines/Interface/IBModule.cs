using Data.Implements;
using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Interface
{
    public interface IBModule
    {
        Task Delete(int Id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<ModuleDto> GetById(int Id);
        Task<PagedListDto<ModuleDto>> GetDataTable(QueryFilterDto filters);
        Task<Module> Save(ModuleDto entity);

        Task Update(int Id, ModuleDto entity);
    }
}
