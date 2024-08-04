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
     public interface IBUser_role
    {
        Task Delete(int Id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<User_roleDto> GetById(int Id);
        Task<PagedListDto<User_roleDto>> GetDataTable(QueryFilterDto filters);
        Task<User_role> Save(User_roleDto entity);

        Task Update(int Id, User_roleDto entity);
    }
}
