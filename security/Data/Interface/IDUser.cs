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
    public interface IDUser
    {
        Task Delete(int Id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<User> GetById(int Id);
        Task<PagedListDto<UserDto>> GetDataTable(QueryFilterDto filters);
        Task<User> Save(User entity);

        Task Update(User user);
    }
}
