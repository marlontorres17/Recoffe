using Entity.DTO;
using Data.Interface;
using Entity.Model.Contexts;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements
{
    public record NewRecord(object Filter);

    public class DPerson : IDPerson
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public DPerson(ApplicationDbContexts context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            context.Persons.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Email, ' - ', Genero) AS TextoMostrar 
                    FROM 
                        Security.Persons
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Person> GetById(int id)
        {
            var sql = @"SELECT * FROM security.Persons WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Person>(sql, new { Id = id });
        }

        public async Task<PagedListDto<PersonDto>> GetDataTable(QueryFilterDto filter)
        {
            int pageNumber = (filter.PageNumber == 0) ? Int32.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
            int pageSize = (filter.PageSize == 0) ? Int32.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

            var sql = @"SELECT
                        pr.Id,
                        pr.Email
                       
                    FROM security.Persons pr
                        
                        ORDER BY '" + (filter.ColumnOrder ?? "Id") + "' " + (filter.DirectionOrder ?? "asc");

            IEnumerable<PersonDto> items = await context.QueryAsync<PersonDto>(sql, new NewRecord(filter.Filter));

            var pagedItems = PagedListDto<PersonDto>.Create(items, pageNumber, pageSize);

            return pagedItems;
        }

        public async Task<Person> Save(Person entity)
        {
            context.Persons.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Person entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Person> GetByCode(string code)
        {
            return await this.context.Persons.AsNoTracking().Where(item => item.Email == code).FirstOrDefaultAsync();
        }

        
    }
}
