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
    public interface IBUser
    {
        Task Delete(int Id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<UserDto> GetById(int Id);
        Task<PagedListDto<UserDto>> GetDataTable(QueryFilterDto filters);
        Task<User> Save(UserDto entity);

        Task Update(int Id, UserDto entity);
    }
}
