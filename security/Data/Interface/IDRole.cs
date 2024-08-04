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
    public interface IDRole
    {
        Task Delete(int Id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Role> GetById(int Id);
        Task<PagedListDto<RoleDto>> GetDataTable(QueryFilterDto filters);
        Task<Role> Save(Role entity);
        Task Update(Role role);
    }
}
