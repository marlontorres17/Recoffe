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
    public interface IDPerson
    {
        Task Delete(int  Id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Person> GetById(int Id);
        Task<PagedListDto<PersonDto>> GetDataTable(QueryFilterDto filters);
        Task<Person> Save(Person entity);
        
        Task Update(Person person);
    }
}
