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
    public interface IBPerson
    {
        Task Delete(int Id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<PersonDto> GetById(int Id);
        Task<PagedListDto<PersonDto>> GetDataTable(QueryFilterDto filters);
        Task<Person> Save(PersonDto entity);

        Task Update(int Id, PersonDto entity);
    }
}
