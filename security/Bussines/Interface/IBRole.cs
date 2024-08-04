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
    public interface IBRole
    {
        Task Delete(int Id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<RoleDto> GetById(int Id);
        Task<PagedListDto<RoleDto>> GetDataTable(QueryFilterDto filters);
        Task<Role> Save(RoleDto entity);
        Task Update(int Id, RoleDto entity);
    }
}
