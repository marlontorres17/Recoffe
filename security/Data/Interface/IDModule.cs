using Data.Implements;
using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IDModule
    {
        Task Delete(int Id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Module> GetById(int Id);
        Task<PagedListDto<ModuleDto>> GetDataTable(QueryFilterDto filters);
        Task<Module> Save(Module entity);

        Task Update(Module module);
    }
}
