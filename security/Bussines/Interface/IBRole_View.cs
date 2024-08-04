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
    public interface IBRole_View
    {
        Task Delete(int Id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Role_ViewDto> GetById(int Id);
        Task<PagedListDto<Role_ViewDto>> GetDataTable(QueryFilterDto filters);
        Task<Role_View> Save(Role_ViewDto entity);

        Task Update(int Id, Role_ViewDto entity);
    }
}
