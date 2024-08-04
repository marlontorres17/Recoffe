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
    public interface IDUser_role
    {
        Task Delete(int Id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<User_role> GetById(int Id);
        Task<PagedListDto<User_roleDto>> GetDataTable(QueryFilterDto filters);
        Task<User_role> Save(User_role entity);

        Task Update(User_role user_Role);
    }
}
