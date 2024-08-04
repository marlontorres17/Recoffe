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
    public class DRole : IDRole
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public DRole(ApplicationDbContexts context, IConfiguration configuration)
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
            context.Roles.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Nombre, ' - ', Descripcion) AS TextoMostrar 
                    FROM 
                        Security.Roles
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Role> GetById(int id)
        {
            var sql = @"SELECT * FROM security.Roles WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Role>(sql, new { Id = id });
        }

        public async Task<PagedListDto<RoleDto>> GetDataTable(QueryFilterDto filter)
        {
            int pageNumber = (filter.PageNumber == 0) ? Int32.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
            int pageSize = (filter.PageSize == 0) ? Int32.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

            var sql = @"SELECT
                        rl.Id,
                        rl.Nombre
                       
                    FROM security.Roles rl
                        
                        ORDER BY '" + (filter.ColumnOrder ?? "Id") + "' " + (filter.DirectionOrder ?? "asc");

            IEnumerable<RoleDto> items = await context.QueryAsync<RoleDto>(sql, new NewRecord(filter.Filter));

            var pagedItems = PagedListDto<RoleDto>.Create(items, pageNumber, pageSize);

            return pagedItems;
        }

        public async Task<Role> Save(Role entity)
        {
            context.Roles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Role entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Role> GetByCode(string code)
        {
            return await this.context.Roles.AsNoTracking().Where(item => item.Nombre == code).FirstOrDefaultAsync();
        }


    }
    public record NewRecordR(object Filter);
}
