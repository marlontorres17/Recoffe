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
    public interface IDView
    {
        Task Delete(int Id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<View> GetById(int Id);
        Task<PagedListDto<ViewDto>> GetDataTable(QueryFilterDto filters);
        Task<View> Save(View entity);

        Task Update(View view);
    }
}
