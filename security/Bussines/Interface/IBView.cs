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
    public interface IBView
    {
        Task Delete(int Id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<ViewDto> GetById(int Id);
        Task<PagedListDto<ViewDto>> GetDataTable(QueryFilterDto filters);
        Task<View> Save(ViewDto entity);

        Task Update(int Id, ViewDto entity);
    }
}
