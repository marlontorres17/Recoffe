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
    public interface IDRole_View
    {
        Task Delete(int Id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Role_View> GetById(int Id);
        Task<PagedListDto<Role_ViewDto>> GetDataTable(QueryFilterDto filters);
        Task<Role_View> Save(Role_View entity);

        Task Update(Role_View role_view);
    }
}
