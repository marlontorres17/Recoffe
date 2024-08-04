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
    public class DModule : IDModule
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public DModule(ApplicationDbContexts context, IConfiguration configuration)
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
            context.Modules.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Nombre, ' - ', Descripcion) AS TextoMostrar 
                    FROM 
                        Security.Modules
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Module> GetById(int id)
        {
            var sql = @"SELECT * FROM security.Modules WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Module>(sql, new { Id = id });
        }

        public async Task<PagedListDto<ModuleDto>> GetDataTable(QueryFilterDto filter)
        {
            int pageNumber = (filter.PageNumber == 0) ? Int32.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
            int pageSize = (filter.PageSize == 0) ? Int32.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

            var sql = @"SELECT
                        md.Id,
                        md.Nombre
                       
                    FROM security.Modules md
                        
                        ORDER BY '" + (filter.ColumnOrder ?? "Id") + "' " + (filter.DirectionOrder ?? "asc");

            IEnumerable<ModuleDto> items = await context.QueryAsync<ModuleDto>(sql, new NewRecord(filter.Filter));

            var pagedItems = PagedListDto<ModuleDto>.Create(items, pageNumber, pageSize);

            return pagedItems;
        }

        public async Task<Module> Save(Module entity)
        {
            context.Modules.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Module entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Module> GetByCode(string code)
        {
            return await this.context.Modules.AsNoTracking().Where(item => item.Nombre == code).FirstOrDefaultAsync();
        }

       
    }
    public record NewRecordM(object Filter);
}
